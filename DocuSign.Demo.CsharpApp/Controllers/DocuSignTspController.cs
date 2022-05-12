using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DocuSign.Demo.CsharpApp.Services;
using DocuSign.Demo.CsharpApp.Settings;
using DocuSign.Demo.SignatureProvider.CA;
using DocuSign.Tsp.Model; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocuSign.Demo.CsharpApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocuSignTspController: Controller
    {
        private readonly DocuSignSettings _dsConfig;
        private readonly IHttpClientFactory _httpClientFactory;

        public DocuSignTspController(DocuSignSettings dsConfig, IHttpClientFactory httpClientFactory)
        {
            _dsConfig = dsConfig;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public string Get()
        {
            return "It Works!";
        }

        [HttpGet("{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> StartTspFlow([FromQuery(Name = "code")] string authorizationCode)
        {
            // First step is to get a token with the retrieve friom the query param
            SignatureOAuthUserToken signatureOAuthUserToken;
            try
            {
                signatureOAuthUserToken = await DocuSignService.GetBearerTokenFromCodeAsync(_httpClientFactory, _dsConfig, authorizationCode);
            }
            catch (Exception e)
            {
                // If you ending up in this case, make sure you clientId/clientSecret are good
                // Also make sure you are hitting the right environement
                return BadRequest(e);
            }
            

            // Initialize DocuSign ApiClient
            var apiClient = new eSign.Client.ApiClient(signatureOAuthUserToken.user_api + "/restapi");
            apiClient.Configuration.AddDefaultHeader("Authorization", "Bearer " + signatureOAuthUserToken.access_token);

            DocuSign.eSign.Api.SignatureApi signatureApi = new eSign.Api.SignatureApi(apiClient);

            // UserInfo
            var userInfoResult = signatureApi.UserInfo();

            UserCertificate userCertificate = new UserCertificate(userInfoResult.User.DisplayName, userInfoResult.User.Email, userInfoResult.Language.ToUpper(), "DocuSign");

            var SignHashSessionInfoResult = signatureApi.SignHashSessionInfo(new eSign.Model.SignSessionInfoRequest(Convert.ToBase64String(userCertificate.CertContainer.Certificate.GetEncoded())));

            if (SignHashSessionInfoResult.Documents[0] == null || SignHashSessionInfoResult.Documents[0].RemainingSignatures == 0L)
            {
                return Ok("Nothing to sign");
            }

            byte[] hashBytes = System.Convert.FromBase64String(SignHashSessionInfoResult.Documents[0].Data);
            byte[] signedCmsData = SignatureProvider.SignatureProvider.Sign(hashBytes, userCertificate);

            eSign.Model.DocumentUpdateInfo docInfo = new eSign.Model.DocumentUpdateInfo()
            {
                DocumentId = SignHashSessionInfoResult.Documents[0].DocumentId,
                Data = Convert.ToBase64String(signedCmsData),
                ReturnFormat = "CMS"
            };
            var CompleteSignHashResult = signatureApi.CompleteSignHash(new eSign.Model.CompleteSignRequest() { DocumentUpdateInfos = new List<eSign.Model.DocumentUpdateInfo> { docInfo } });

            ViewBag.CompleteResult = CompleteSignHashResult;

            return Redirect(CompleteSignHashResult.RedirectionUrl);
        }

        #region eSeal Flow
        [HttpGet("{env_slt}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> StarteSealTspFlow([FromQuery(Name = "env_slt")] string envSlt)
        {
            // First step is to get a token with the retrieve friom the query param
            SignatureOAuthUserToken signatureOAuthUserToken;
            try
            {
                signatureOAuthUserToken = await DocuSignService.GetBearerTokenFromEnvSltAsync(_httpClientFactory, _dsConfig, envSlt);
            }
            catch (Exception e)
            {
                // If you ending up in this case, make sure you clientId/clientSecret are good
                // Also make sure you are hitting the right environement
                return BadRequest(e);
            }


            // Initialize DocuSign ApiClient
            var apiClient = new eSign.Client.ApiClient(signatureOAuthUserToken.user_api + "/restapi");
            apiClient.Configuration.AddDefaultHeader("Authorization", "Bearer " + signatureOAuthUserToken.access_token);

            DocuSign.eSign.Api.SignatureApi signatureApi = new eSign.Api.SignatureApi(apiClient);

            // UserInfo
            var userInfoResult = signatureApi.UserInfo();

            UserCertificate userCertificate = new UserCertificate(userInfoResult.User.DisplayName, userInfoResult.User.Email, userInfoResult.Language.ToUpper(), "DocuSign");

            var SignHashSessionInfoResult = signatureApi.SignHashSessionInfo(new eSign.Model.SignSessionInfoRequest(Convert.ToBase64String(userCertificate.CertContainer.Certificate.GetEncoded())));

            if (SignHashSessionInfoResult.Documents[0] == null || SignHashSessionInfoResult.Documents[0].RemainingSignatures == 0L)
            {
                return Ok("Nothing to sign");
            }

            byte[] hashBytes = System.Convert.FromBase64String(SignHashSessionInfoResult.Documents[0].Data);
            byte[] signedCmsData = SignatureProvider.SignatureProvider.Sign(hashBytes, userCertificate);

            eSign.Model.DocumentUpdateInfo docInfo = new eSign.Model.DocumentUpdateInfo()
            {
                DocumentId = SignHashSessionInfoResult.Documents[0].DocumentId,
                Data = Convert.ToBase64String(signedCmsData),
                ReturnFormat = "CMS"
            };
            var CompleteSignHashResult = signatureApi.CompleteSignHash(new eSign.Model.CompleteSignRequest() { DocumentUpdateInfos = new List<eSign.Model.DocumentUpdateInfo> { docInfo } });

            ViewBag.CompleteResult = CompleteSignHashResult;

            return Redirect(CompleteSignHashResult.RedirectionUrl);
        }
        #endregion
    }
}
