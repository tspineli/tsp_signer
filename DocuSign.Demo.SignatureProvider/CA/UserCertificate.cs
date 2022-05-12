using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;

namespace DocuSign.Demo.SignatureProvider.CA
{
    public class UserCertificate
    {
        private CertContainer _certContainer;
        public CertContainer CertContainer
        {
            get
            {
                if (this._certContainer != null)
                {
                    return this._certContainer;
                }

                // Fall back to the regular signer cert
                return CAManager.DefaultSignerCert;
            }
        }

        #region Ctor
        /// <summary>
        /// User Certificate will create generate a default certificate
        /// with the provided informations
        /// </summary>
        /// <param name="name">Name of the signer (CN of the certificate)</param>
        /// <param name="emailAddress">E-Mail of the signer (part of the certificate)</param>
        /// <param name="countryCode">Two letters country code (C of the certificate)</param>
        /// <param name="orgName">Organisation (O of the certificate)</param>
        public UserCertificate(string name, string emailAddress, string countryCode = null, string orgName = null)
        {
            string[] requiredProperties = { name, emailAddress };
            if (!requiredProperties.Any(string.IsNullOrEmpty))
            {
                X509Name subjectName = GenerateDNName(name, emailAddress, countryCode, orgName);
                this._certContainer = CAManager.IssueSignerCertificate(subjectName);
            }
        }
        #endregion

        private static X509Name GenerateDNName(string commonName, string emailAddress, string countryCode, string organization)
        {
            IList ordering = new List<DerObjectIdentifier>();
            IDictionary attributes = new Dictionary<DerObjectIdentifier, string>();

            if (!string.IsNullOrEmpty(commonName))
            {
                ordering.Add(X509Name.CN);
                attributes.Add(X509Name.CN, commonName);
            }

            if (!string.IsNullOrEmpty(emailAddress))
            {
                ordering.Add(X509Name.EmailAddress);
                attributes.Add(X509Name.EmailAddress, emailAddress);
            }

            if (!string.IsNullOrEmpty(countryCode))
            {
                ordering.Add(X509Name.C);
                attributes.Add(X509Name.C, countryCode);
            }

            if (!string.IsNullOrEmpty(organization))
            {
                ordering.Add(X509Name.O);
                attributes.Add(X509Name.O, organization);
            }

            X509Name dnName = new X509Name(ordering, attributes);
            return dnName;
        }
    }
}
