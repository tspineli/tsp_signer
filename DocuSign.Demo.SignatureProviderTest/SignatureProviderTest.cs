using System;
using System.IO;  
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.X509.Store;
using DocuSign.Demo.SignatureProvider.CA;

namespace DocuSign.Demo.SignatureProviderTest
{
    [TestClass]
    public class SignatureProviderTest
    {
        private const string SignerName = "Tiago Spineli";
        private const string SignerEmail = "tspineli02@gmail.com";
        private const string SignerCountry = "BR";
        private const string SignerOrganization = "Rockstar";

        //private const string Base64encodedHashToSign = "LH8U4Y4iR9XPDptIxXDNSYdQJwAKSCAmk2jxuDwdYbQ=";

        static readonly string textFile = "/tmp/tmp.txt";  

        [TestMethod]
        public void TestSignHashWithBouncyCastle()
        {
            UserCertificate userCertificate = new UserCertificate(SignerName, SignerEmail, SignerCountry, SignerOrganization);
            System.Diagnostics.Debug.WriteLine(Convert.ToBase64String(userCertificate.CertContainer.Certificate.GetEncoded()));

            string Base64encodedHashToSign = File.ReadAllText(textFile);
                    
            byte[] hashBytes = System.Convert.FromBase64String(Base64encodedHashToSign);

            byte[] signedCmsData = SignatureProvider.SignatureProvider.Sign(hashBytes, userCertificate);
            System.Diagnostics.Debug.WriteLine(Convert.ToBase64String(signedCmsData));


        }
    }
}
