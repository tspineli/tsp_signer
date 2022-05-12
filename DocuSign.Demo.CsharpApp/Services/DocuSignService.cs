using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DocuSign.Demo.CsharpApp.Settings;
using DocuSign.Tsp.Model;
using Newtonsoft.Json;

namespace DocuSign.Demo.CsharpApp.Services
{
    public static class DocuSignService
    {
        #region eSign TSP Flow
        private static HttpRequestMessage BuildBearerTokenFromCodeRequest(DocuSignSettings dsconfig, string code)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, dsconfig.IDPServerBaseUrl + "/oauth/token");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string authorizationHeaderValue = string.Format("{0}:{1}", dsconfig.ClientId
                , dsconfig.ClientSecret);
            string base64HeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authorizationHeaderValue));

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64HeaderValue);

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", code),
                // The redirect_uri one is not really used in the TSP flow
                new KeyValuePair<string, string>("redirect_uri", String.Format("https://{0}", "localhost:5001/api/docusigntsp/starttspflow")),
            });

            request.Content = content;

            return request;
        }

        public static async Task<SignatureOAuthUserToken> GetBearerTokenFromCodeAsync(IHttpClientFactory httpClientFactory, DocuSignSettings dsConfig, string code)
        {
            HttpRequestMessage request = DocuSignService.BuildBearerTokenFromCodeRequest(dsConfig, code);

            var client = httpClientFactory.CreateClient();
            var response = await client.SendAsync(request);
            var responseContent = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode < HttpStatusCode.OK && response.StatusCode >= HttpStatusCode.BadRequest)
            {
                throw new Exception(response.Headers.ToString() + "\n" + responseContent);
            }

            return JsonConvert.DeserializeObject<SignatureOAuthUserToken>(responseContent);
        }
        #endregion

        #region eSeal Flow
        private static HttpRequestMessage BuildBearerTokenFromEnvSltRequest(DocuSignSettings dsconfig, string envSlt)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, dsconfig.IDPServerBaseUrl + "/oauth/token");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string authorizationHeaderValue = string.Format("{0}:{1}", dsconfig.ClientId
                , dsconfig.ClientSecret);
            string base64HeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authorizationHeaderValue));

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64HeaderValue);

            var content = new FormUrlEncodedContent(new[]
            {
                // For eSeal should be. code from env_slt
                new KeyValuePair<string, string>("grant_type", "docusign:params:oauth:grant-type:envelope-slt"),
                new KeyValuePair<string, string>("env_slt", envSlt),
                // The redirect_uri one is not really used in the TSP flow
                new KeyValuePair<string, string>("redirect_uri", String.Format("https://{0}", "localhost:5001/api/docusigntsp/starttspflow")),
            });

            request.Content = content;

            return request;
        }

        public static async Task<SignatureOAuthUserToken> GetBearerTokenFromEnvSltAsync(IHttpClientFactory httpClientFactory, DocuSignSettings dsConfig, string code)
        {
            HttpRequestMessage request = DocuSignService.BuildBearerTokenFromEnvSltRequest(dsConfig, code);

            var client = httpClientFactory.CreateClient();
            var response = await client.SendAsync(request);
            var responseContent = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode < HttpStatusCode.OK && response.StatusCode >= HttpStatusCode.BadRequest)
            {
                throw new Exception(response.Headers.ToString() + "\n" + responseContent);
            }

            return JsonConvert.DeserializeObject<SignatureOAuthUserToken>(responseContent);
        }
        #endregion
    }

}
