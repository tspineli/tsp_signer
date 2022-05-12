using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DocuSign.Demo.CsharpApp.Services;
using DocuSign.Demo.CsharpApp.Settings;
using DocuSign.Demo.SignatureProvider.CA;
using DocuSign.eSign.Model;
using DocuSign.Tsp.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DocuSign.Demo.CsharpApp.Pages.DocuSignTsp
{
    public class StartTspFlowModel : PageModel
    {
        private readonly DocuSignSettings _dsConfig;
        private readonly IHttpClientFactory _httpClientFactory;

        public SignatureOAuthUserToken SignatureOAuthUserToken { get; set; }
        public UserInfoResponse UserInfoResponse { get; set; }

        public StartTspFlowModel(DocuSignSettings dsconfig, IHttpClientFactory clientFactory)
        {
            _dsConfig = dsconfig;
            _httpClientFactory = clientFactory;
        }


        public async Task OnGetAsync(string authorizationCode)
        {
            // First step is to get a token with the retrieve friom the query param
            try
            {
                SignatureOAuthUserToken = await DocuSignService.GetBearerTokenFromCodeAsync(_httpClientFactory, _dsConfig, authorizationCode);
            }
            catch (Exception e)
            {
                // If you ending up in this case, make sure you clientId/clientSecret are good
                // Also make sure you are hitting the right environement
                ViewData["Error"] = e;
            }


            // Initialize DocuSign ApiClient
            var apiClient = new eSign.Client.ApiClient(SignatureOAuthUserToken.user_api + "/restapi");
            apiClient.Configuration.AddDefaultHeader("Authorization", "Bearer " + SignatureOAuthUserToken.access_token);

            DocuSign.eSign.Api.SignatureApi signatureApi = new eSign.Api.SignatureApi(apiClient);

            // Get UserInfo
            var userInfoResponse = signatureApi.UserInfo();
            ViewData["UserInfo"] = JsonConvert.SerializeObject(userInfoResponse);
            UserCertificate userCertificate = new UserCertificate(UserInfoResponse.User.DisplayName, UserInfoResponse.User.Email, UserInfoResponse.Language.ToUpper(), "DocuSign");
           

            //var SignHashSessionInfoResult = signatureApi.SignHashSessionInfo(new eSign.Model.SignSessionInfoRequest(Convert.ToBase64String(userCertificate.CertContainer.Certificate.GetEncoded())));

            //if (SignHashSessionInfoResult.Documents[0] == null || SignHashSessionInfoResult.Documents[0].RemainingSignatures == "0")
            //{
            //    return Ok("Nothing to sign");
            //}

            //byte[] hashBytes = System.Convert.FromBase64String(SignHashSessionInfoResult.Documents[0].Data);
            //byte[] signedCmsData = SignatureProvider.SignatureProvider.Sign(hashBytes, userCertificate);

            //eSign.Model.DocumentUpdateInfo docInfo = new eSign.Model.DocumentUpdateInfo()
            //{
            //    DocumentId = SignHashSessionInfoResult.Documents[0].DocumentId,
            //    Data = Convert.ToBase64String(signedCmsData),
            //    ReturnFormat = "CMS"
            //};
            //var CompleteSignHashResult = signatureApi.CompleteSignHash(new eSign.Model.CompleteSignRequest() { DocumentUpdateInfos = new List<eSign.Model.DocumentUpdateInfo> { docInfo } });

            //ViewBag.CompleteResult = CompleteSignHashResult;

            //return Redirect(CompleteSignHashResult.RedirectionUrl);
        }
    }
}
