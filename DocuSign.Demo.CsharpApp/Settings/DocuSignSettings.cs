using System.ComponentModel.DataAnnotations;

namespace DocuSign.Demo.CsharpApp.Settings
{
    public class DocuSignSettings : IValidatable
    {
        /// <summary>
        /// ClientID that will be create via the Developer
        /// sandbox as described here: https://developers.docusign.com/id-tsp-api/guides
        /// </summary>
        [Required]
        public string ClientId { get; set; }

        /// <summary>
        /// ClientSecret will be generated when creating the ClientId
        /// </summary>
        [Required]
        public string ClientSecret { get; set; }

        /// <summary>
        /// IDPServerBaseUrl depends which DocuSign environment you
        /// are working with. Usually it will be
        /// https://account-d.docusign.com Demo environment
        /// https://account.docusign.com Prod environment
        /// </summary>
        [Required, Url]
        public string IDPServerBaseUrl { get; set; }


        public void Validate()
        {
            Validator.ValidateObject(this,
                new ValidationContext(this),
                validateAllProperties: true);
        }
    }
}
