using System;
using System.IO;
using System.Reflection;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.X509.Extension;

namespace DocuSign.Demo.SignatureProvider.CA
{ 
    internal static class CAManager
    {
        #region Resource Names

        private const string ResourcePath = @"DocuSign.Demo.SignatureProvider.Resources.";

        private const string RootCaPfx = ResourcePath + "DocuSignDemoRootCA.p12";
        private const string RootCaPfxPassword = "docusign";

        private const string IntermediateCaPfx = ResourcePath + "DocuSignDemoIntermediateCA.p12";
        private const string IntermediatePfxPassword = "docusign";

        private const string DefaultSignerCertPfx = ResourcePath + "IntermediateCA-DefaultSigner.p12";
        private const string DefaultSignerCertPfxPassword = "69866640";

        #endregion

        #region Certificate Generation Constanst
        private const int DefaultKeySize = 2048;
        private const string IntermediateCrlPath = "/Revocation/Intermediate1Crl";
        private const string OcspPath = "/Revocation/Ocsp";
        #endregion

        private static SecureRandom _secureRandom = new SecureRandom();

        public static readonly CertContainer RootCa;
        public static readonly CertContainer IntermediateCa;
        public static readonly CertContainer DefaultSignerCert;


        static CAManager()
        {
            RootCa =
                new CertContainer(GetPkcs12Store(RootCaPfx, RootCaPfxPassword));
            IntermediateCa =
                new CertContainer(GetPkcs12Store(IntermediateCaPfx, IntermediatePfxPassword), RootCa);
            DefaultSignerCert =
                new CertContainer(GetPkcs12Store(DefaultSignerCertPfx, DefaultSignerCertPfxPassword), IntermediateCa, RootCa);
        }

        private static Pkcs12Store GetPkcs12Store(string pfxName, string pfxPassword)
        {
            Stream privateKeyStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(pfxName);
            Pkcs12Store privateKeyStore = new Pkcs12Store(privateKeyStream, pfxPassword.ToCharArray());

            return privateKeyStore;
        }

        [Obsolete]
        internal static CertContainer IssueSignerCertificate(X509Name dnName, int keySize = DefaultKeySize)
        {
            CertContainer issuerCert = IntermediateCa;

            RsaKeyPairGenerator keyPairGen = new RsaKeyPairGenerator();
            keyPairGen.Init(new KeyGenerationParameters(_secureRandom, keySize));
            AsymmetricCipherKeyPair keyPair = keyPairGen.GenerateKeyPair();

            X509V3CertificateGenerator certGen = new X509V3CertificateGenerator();
            certGen.SetSerialNumber(BigInteger.One);
            certGen.SetIssuerDN(issuerCert.Certificate.SubjectDN);
            certGen.SetNotBefore(DateTime.Now);
            certGen.SetNotAfter(DateTime.Now.AddYears(1));

            certGen.SetSubjectDN(dnName);
            certGen.SetPublicKey(keyPair.Public);
            certGen.SetSignatureAlgorithm("SHA256withRSA");
            certGen.AddExtension(X509Extensions.AuthorityKeyIdentifier, false, new AuthorityKeyIdentifierStructure(issuerCert.Certificate.GetPublicKey()));
            certGen.AddExtension(X509Extensions.BasicConstraints, true, new BasicConstraints(false));
            certGen.AddExtension(X509Extensions.KeyUsage, true, new KeyUsage(X509KeyUsage.NonRepudiation | X509KeyUsage.DigitalSignature));
            certGen.AddExtension(X509Extensions.SubjectKeyIdentifier, false, new SubjectKeyIdentifierStructure(keyPair.Public));
            certGen.AddExtension(X509Extensions.ExtendedKeyUsage, false, new ExtendedKeyUsage(KeyPurposeID.IdKPClientAuth));

            // Add CRL endpoint
            Uri currentBaseUri = new Uri("https://localhost/");
            Uri crlUri = new Uri(currentBaseUri, IntermediateCrlPath);

            GeneralName generalName = new GeneralName(GeneralName.UniformResourceIdentifier, crlUri.ToString());
            GeneralNames generalNames = new GeneralNames(generalName);
            DistributionPointName distPointName = new DistributionPointName(generalNames);
            DistributionPoint distPoint = new DistributionPoint(distPointName, null, null);
            certGen.AddExtension(X509Extensions.CrlDistributionPoints, false, new CrlDistPoint(new DistributionPoint[] { distPoint }));

            // Add OCSP endpoint
            Uri ocspUri = new Uri(currentBaseUri, OcspPath);
            AccessDescription ocsp = new AccessDescription(AccessDescription.IdADOcsp,
                    new GeneralName(GeneralName.UniformResourceIdentifier, ocspUri.ToString()));

            Asn1EncodableVector aiaASN = new Asn1EncodableVector();
            aiaASN.Add(ocsp);

            certGen.AddExtension(X509Extensions.AuthorityInfoAccess, false, new DerSequence(aiaASN));

            X509Certificate generatedCert = certGen.Generate(issuerCert.PrivateKey);

            Pkcs12StoreBuilder pfxBuilder = new Pkcs12StoreBuilder();
            Pkcs12Store pfxStore = pfxBuilder.Build();

            X509CertificateEntry certEntry = new X509CertificateEntry(generatedCert);
            pfxStore.SetCertificateEntry(generatedCert.SubjectDN.ToString(), certEntry);
            pfxStore.SetKeyEntry(generatedCert.SubjectDN + "_key", new AsymmetricKeyEntry(keyPair.Private), new X509CertificateEntry[] { certEntry });

            return new CertContainer(pfxStore, issuerCert.GetIssuerChain(true));
        }
    }
}
