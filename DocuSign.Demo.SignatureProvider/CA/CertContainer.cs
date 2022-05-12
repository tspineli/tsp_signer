using System;
using System.IO;
using System.Linq;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;

namespace DocuSign.Demo.SignatureProvider.CA
{
    public class CertContainer
    {
        public X509Certificate Certificate { get; }
        public CertContainer[] IssuerChain { get; }
        internal AsymmetricKeyParameter PrivateKey { get; }

        #region Ctor
        public CertContainer(Pkcs12Store privateKeyStore, params CertContainer[] issuerCerts)
        {
            string certAlias = GetCertAlias(privateKeyStore);

            this.PrivateKey = privateKeyStore.GetKey(certAlias).Key;
            this.Certificate = privateKeyStore.GetCertificate(certAlias).Certificate;
            this.IssuerChain = issuerCerts ?? new CertContainer[0];
        }
        #endregion

        private static string GetCertAlias(Pkcs12Store privateKeyStore)
        {
            foreach (string al in privateKeyStore.Aliases)
            {
                if (privateKeyStore.IsKeyEntry(al) && privateKeyStore.GetKey(al).Key.IsPrivate)
                {
                    return al;
                }
            }

            return null;
        }

        public CertContainer[] GetIssuerChain(bool includeCert)
        {
            if (!includeCert)
            {
                return this.IssuerChain.ToArray();
            }

            return new CertContainer[] { this }.Concat(this.IssuerChain).ToArray();
        }
    }
}
