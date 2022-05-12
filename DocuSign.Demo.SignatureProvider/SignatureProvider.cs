using System;
using System.Collections.Generic;
using System.Linq;
using DocuSign.Demo.SignatureProvider.CA;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Ess;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.X509.Store;
using BCAttribute = Org.BouncyCastle.Asn1.Cms.Attribute;

namespace DocuSign.Demo.SignatureProvider
{
    public class SignatureProvider
    {

        private const string Sha256WithRsa = "SHA256withRSA";
        private const string Sha256Oid = "2.16.840.1.101.3.4.2.1";

        #region Public Sign operations
        /// <summary>
        /// Sign the specified dataToSign with a certificate.
        /// that will be created
        /// </summary>
        /// <param name="dataToSign"></param>
        /// <param name="signerCommonName"></param>
        /// <param name="signerEmail"></param>
        /// <param name="countryCode"></param>
        /// <param name="companyName"></param>
        /// <returns>Encoded CMSSignedData</returns>
        public static byte[] Sign(byte[] dataToSign, string signerCommonName, string signerEmail, string countryCode = null, string companyName = null)
        {
            UserCertificate userCertificate = new UserCertificate(signerCommonName, signerEmail, countryCode, companyName);
            //System.Diagnostics.Debug.WriteLine(Convert.ToBase64String(userCertificate.CertContainer.Certificate.GetEncoded()));
            return Sign(dataToSign, userCertificate.CertContainer.Certificate, userCertificate.CertContainer.PrivateKey);
        }

        /// <summary>
        /// Sign the specified dataToSign with the certificate.
        /// </summary>
        /// <param name="dataToSign">Data to sign.</param>
        /// <param name="userCertificate">user certificate</param>
        /// <returns>Encoded CMSSignedData</returns>
        public static byte[] Sign(byte[] dataToSign, UserCertificate userCertificate)
        {
            return Sign(dataToSign, userCertificate.CertContainer.Certificate, userCertificate.CertContainer.PrivateKey);
        }

        /// <summary>
        /// Sign the specified dataToSign with the certificate.
        /// </summary>
        /// <param name="dataToSign">Data to sign.</param>
        /// <param name="signerCertificate">Signer certificate</param>
        /// <param name="privateKey">PrivateKey associated to the certificate</param>
        /// <returns>Encoded CMSSignedData</returns>
        public static byte[] Sign(byte[] dataToSign, X509Certificate signerCertificate, AsymmetricKeyParameter privateKey)
        {
            DerSet signingData = CreateSignedAttributes(dataToSign, signerCertificate);
            byte[] signedCmsData = GenerateSignedCmsData(signingData, signerCertificate, privateKey);

            return signedCmsData;
        }
        #endregion

        #region Signature Generation
        /// <summary>
        /// Creates the signed attributes.
        /// </summary>
        /// <returns>The signed attributes.</returns>
        /// <param name="docHash">Document hash.</param>
        /// <param name="signingCert">Signing cert.</param>
        private static DerSet CreateSignedAttributes(byte[] docHash, X509Certificate signingCert)
        {
            Asn1EncodableVector signedAttrs = new Asn1EncodableVector();

            signedAttrs.Add(new BCAttribute(
                PkcsObjectIdentifiers.Pkcs9AtContentType,
                new DerSet(PkcsObjectIdentifiers.Data)
            ));

            signedAttrs.Add(new BCAttribute(
                PkcsObjectIdentifiers.Pkcs9AtMessageDigest,
                new DerSet(new DerOctetString(docHash))
            ));

            // IdAASignerCertificateV2
            byte[] certHash = CalculateSha256Hash(signingCert.GetEncoded());

            GeneralNames issuer = new GeneralNames(new GeneralName(signingCert.IssuerDN));
            IssuerSerial issuerSerial = new IssuerSerial(issuer, new DerInteger(signingCert.SerialNumber));
            AlgorithmIdentifier algIdentifier =
                new AlgorithmIdentifier(new DerObjectIdentifier(Sha256Oid));

            EssCertIDv2 essCert = new EssCertIDv2(algIdentifier, certHash, issuerSerial);
            SigningCertificateV2 scv2 = new SigningCertificateV2(new EssCertIDv2[] { essCert });

            signedAttrs.Add(new BCAttribute(
                PkcsObjectIdentifiers.IdAASigningCertificateV2,
                new DerSet(scv2)
            ));

            signedAttrs.Add(new BCAttribute(
                PkcsObjectIdentifiers.Pkcs9AtSigningTime,
                new DerSet(new DerUtcTime(System.DateTime.UtcNow))
            ));

            return new DerSet(signedAttrs);
        }

        /// <summary>
        /// Generates the signed cms data.
        /// </summary>
        /// <returns>The signed cms data.</returns>
        /// <param name="signingData">Signing data.</param>
        /// <param name="signerCert">Signer certificate/</param>
        /// <param name="privateKey">Signer private key.</param>
        private static byte[] GenerateSignedCmsData(DerSet signingData, X509Certificate signerCert, AsymmetricKeyParameter privateKey)
        {
            CmsSignedDataGenerator cmsDataGenerator = new CmsSignedDataGenerator();
            IX509Store x509Certs = X509StoreFactory.Create(
                    "Certificate/Collection",
                    new X509CollectionStoreParameters(new X509Certificate[] { signerCert }));
            cmsDataGenerator.AddCertificates(x509Certs);

            Org.BouncyCastle.Asn1.Cms.AttributeTable attTable = new Org.BouncyCastle.Asn1.Cms.AttributeTable(signingData);
            cmsDataGenerator.AddSigner(
                privateKey,
                signerCert,
                SignerUtilities.GetObjectIdentifier(Sha256WithRsa).Id,
                Sha256Oid,
                new SimpleAttributeTableGenerator(attTable),
                null);

            CmsSignedData detachedSignedData = cmsDataGenerator.Generate(null, false);

            return detachedSignedData.GetEncoded();
        }
        #endregion

        #region Utils
        /// <summary>
        /// Calculates the sha256 hash.
        /// </summary>
        /// <returns>The sha256 hash.</returns>
        /// <param name="dataToHash">Data to hash.</param>
        private static byte[] CalculateSha256Hash(byte[] dataToHash)
        {
            IDigest hasher = new Sha256Digest();
            hasher.BlockUpdate(dataToHash, 0, dataToHash.Length);

            byte[] hashResult = new byte[hasher.GetDigestSize()];
            hasher.DoFinal(hashResult, 0);

            return hashResult;
        }
        #endregion
    }
}