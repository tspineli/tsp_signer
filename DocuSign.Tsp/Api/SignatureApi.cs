/*
 * Inspired from DocuSign.eSign.Api
 * https://github.com/docusign/docusign-csharp-client/blob/master/sdk/src/DocuSign.eSign/Api
 */

using System;
using System.Collections.Generic;
using System.Linq;
using DocuSign.eSign.Client;
using DocuSign.eSign.Model;
using RestSharp;

namespace DocuSign.eSign.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISignatureApi : IApiAccessor
    {
        #region Synchronous Operations
        #region UserInfo
        /// <summary>
        /// Provides user information for a Trust Service Provider.
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>UserInfoResponse</returns>
        UserInfoResponse UserInfo();

        /// <summary>
        /// Provides user information for a Trust Service Provider.
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of (UserInfoResponse)</returns>
        ApiResponse<UserInfoResponse> UserInfoWithHttpInfo();
        #endregion UserInfo

        #region SignHashSessionInfo
        /// <summary>
        /// Provides signing session information for a Trust Service Provider. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="signHashSessionInfo">SignSessionInfoRequest object.</param>
        /// <returns>SignHashSessionInfoResponse</returns>
        SignHashSessionInfoResponse SignHashSessionInfo(SignSessionInfoRequest signHashSessionInfo);

        /// <summary>
        /// Provides signing session information for a Trust Service Provider. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="signHashSessionInfo">SignSessionInfoRequest object.</param>
        /// <returns>ApiResponse of (SignHashSessionInfoResponse)</returns>
        ApiResponse<SignHashSessionInfoResponse> SignHashSessionInfoWithHttpInfo(SignSessionInfoRequest signHashSessionInfo);
        #endregion SignHashSessionInfo

        #region CompleteSignHash
        /// <summary>
        /// Finalize the Trust Service Provider session with the signed Hash. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="completeSignRequest">CompleteSignRequest object.</param>
        /// <returns>CompleteSignHashResponse</returns>
        CompleteSignHashResponse CompleteSignHash(CompleteSignRequest completeSignRequest);

        /// <summary>
        /// Finalize the Trust Service Provider session with the signed Hash. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="completeSignRequest">CompleteSignRequest object.</param>
        /// <returns>ApiResponse of (CompleteSignHashResponse)</returns>
        ApiResponse<CompleteSignHashResponse> CompleteSignHashWithHttpInfo(CompleteSignRequest completeSignRequest);
        #endregion CompleteSignHash

        #region SignDocumentSessionInfo
        /// <summary>
        /// Provides signing session information for a Trust Service Provider. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="signDocumentSessionInfo">SignSessionInfoRequest object.</param>
        /// <returns>SignHashSessionInfoResponse</returns>
        SignHashSessionInfoResponse SignDocumentSessionInfo(SignSessionInfoRequest signDocumentSessionInfo);

        /// <summary>
        /// Provides signing session information for a Trust Service Provider. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="signDocumentSessionInfo">SignSessionInfoRequest object.</param>
        /// <returns>ApiResponse of (SignHashSessionInfoResponse)</returns>
        ApiResponse<SignHashSessionInfoResponse> SignDocumentSessionInfoWithHttpInfo(SignSessionInfoRequest signDocumentSessionInfo);
        #endregion SignHashSessionInfo

        #region CompleteSignDocument
        /// <summary>
        /// Finalize the Trust Service Provider session with the signed Hash. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="completeSignRequest">CompleteSignRequest object.</param>
        /// <returns>CompleteSignHashResponse</returns>
        CompleteSignHashResponse CompleteSignDocument(CompleteSignRequest completeSignRequest);

        /// <summary>
        /// Finalize the Trust Service Provider session with the signed Hash. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="completeSignRequest">CompleteSignRequest object.</param>
        /// <returns>ApiResponse of (CompleteSignHashResponse)</returns>
        ApiResponse<CompleteSignHashResponse> CompleteSignDocumentWithHttpInfo(CompleteSignRequest completeSignRequest);
        #endregion CompleteSignDocument

        #region UpdateTransaction
        /// <summary>
        /// Report an error from the Trust Service Provider to DocuSign. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updateTransactionRequest">UpdateTransactionRequest object.</param>
        /// <returns>UpdateTransactionResponse</returns>
        UpdateTransactionResponse UpdateTransaction(UpdateTransactionRequest updateTransactionRequest);

        /// <summary>
        /// Report an error from the Trust Service Provider to DocuSign. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updateTransactionRequest">UpdateTransactionRequest object.</param>
        /// <returns>ApiResponse of (UpdateTransactionResponse)</returns>
        ApiResponse<UpdateTransactionResponse> UpdateTransactionWithHttpInfo(UpdateTransactionRequest updateTransactionRequest);
        #endregion UpdateTransaction
        #endregion Synchronous Operations

        #region Asynchronous Operations
        #region UserInfo
        /// <summary>
        /// Provides user information for a Trust Service Provider.
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>UserInfoResponse</returns>
        System.Threading.Tasks.Task<UserInfoResponse> UserInfoAsync();


        /// <summary>
        /// Provides user information for a Trust Service Provider.
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of (UserInfoResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<UserInfoResponse>> UserInfoAsyncWithHttpInfo();
        #endregion UserInfo

        #region SignHashSessionInfo
        /// <summary>
        /// Provides signing session information for a Trust Service Provider. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="signHashSessionInfo">SignSessionInfoRequest object.</param>
        /// <returns>SignHashSessionInfoResponse</returns>
        System.Threading.Tasks.Task<SignHashSessionInfoResponse> SignHashSessionInfoAsync(SignSessionInfoRequest signHashSessionInfo);


        /// <summary>
        /// Provides signing session information for a Trust Service Provider. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="signHashSessionInfo">SignSessionInfoRequest object.</param>
        /// <returns>ApiResponse of (SignHashSessionInfoResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<SignHashSessionInfoResponse>> SignHashSessionInfoAsyncWithHttpInfo(SignSessionInfoRequest signHashSessionInfo);
        #endregion SignHashSessionInfo

        #region CompleteSignHash
        /// <summary>
        /// Finalize the Trust Service Provider session with the signed Hash. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="completeSignRequest">CompleteSignRequest object.</param>
        /// <returns>CompleteSignHashResponse</returns>
        System.Threading.Tasks.Task<CompleteSignHashResponse> CompleteSignHashAsync(CompleteSignRequest completeSignRequest);

        /// <summary>
        /// Finalize the Trust Service Provider session with the signed Hash. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="completeSignRequest">CompleteSignRequest object.</param>
        /// <returns>ApiResponse of (CompleteSignHashResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<CompleteSignHashResponse>> CompleteSignHashAsyncWithHttpInfo(CompleteSignRequest completeSignRequest);
        #endregion CompleteSignHash

        #region SignDocumentSessionInfo
        /// <summary>
        /// Provides signing session information for a Trust Service Provider. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="signHashSessionInfo">SignSessionInfoRequest object.</param>
        /// <returns>SignHashSessionInfoResponse</returns>
        System.Threading.Tasks.Task<SignHashSessionInfoResponse> SignDocumentSessionInfoAsync(SignSessionInfoRequest signHashSessionInfo);


        /// <summary>
        /// Provides signing session information for a Trust Service Provider. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="signHashSessionInfo">SignSessionInfoRequest object.</param>
        /// <returns>ApiResponse of (SignHashSessionInfoResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<SignHashSessionInfoResponse>> SignDocumentSessionInfoAsyncWithHttpInfo(SignSessionInfoRequest signHashSessionInfo);
        #endregion SignDocumentSessionInfo

        #region CompleteSignDocument
        /// <summary>
        /// Finalize the Trust Service Provider session with the signed Hash. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="completeSignRequest">CompleteSignRequest object.</param>
        /// <returns>CompleteSignHashResponse</returns>
        System.Threading.Tasks.Task<CompleteSignHashResponse> CompleteSignDocumentAsync(CompleteSignRequest completeSignRequest);

        /// <summary>
        /// Finalize the Trust Service Provider session with the signed Hash. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="completeSignRequest">CompleteSignRequest object.</param>
        /// <returns>ApiResponse of (CompleteSignHashResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<CompleteSignHashResponse>> CompleteSignDocumentAsyncWithHttpInfo(CompleteSignRequest completeSignRequest);
        #endregion CompleteSignDocument

        #region UpdateTransaction
        /// <summary>
        /// Report an error from the Trust Service Provider to DocuSign. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updateTransactionRequest">UpdateTransactionRequest object.</param>
        /// <returns>UpdateTransactionResponse</returns>
        System.Threading.Tasks.Task<UpdateTransactionResponse> UpdateTransactionAsync(UpdateTransactionRequest updateTransactionRequest);


        /// <summary>
        /// Report an error from the Trust Service Provider to DocuSign. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updateTransactionRequest">UpdateTransactionRequest object.</param>
        /// <returns>ApiResponse of (UpdateTransactionResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<UpdateTransactionResponse>> UpdateTransactionAsyncWithHttpInfo(UpdateTransactionRequest updateTransactionRequest);
        #endregion UpdateTransaction
        #endregion Asynchronous Operations
    }


    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class SignatureApi : ISignatureApi
    {
        private DocuSign.eSign.Client.ExceptionFactory _exceptionFactory = (name, response) => null;
        private const string _defaultApiPath = "/v2.1/signature";

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="TrustServiceProvidersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SignatureApi(ApiClient apiClient)
        {
            this.ApiClient = apiClient;

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }
        #endregion

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Gets or sets the ApiClient object
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public DocuSign.eSign.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        #region Synchronous Operations
        #region UserInfo
        /// <summary>
        /// Provides user information for a Trust Service Provider.
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>UserInfoResponse</returns>
        public UserInfoResponse UserInfo()
        {
            ApiResponse<UserInfoResponse> localVarResponse = UserInfoWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        /// Provides user information for a Trust Service Provider.
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of (UserInfoResponse)</returns>
        public ApiResponse<UserInfoResponse> UserInfoWithHttpInfo()
        {
            var localVarPath = _defaultApiPath + "/userinfo";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(this.ApiClient.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = { };
            string localVarHttpContentType = this.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = { "application/json" };
            string localVarHttpHeaderAccept = this.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.ApiClient.CallApi(localVarPath,
            Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("UserInfo", localVarResponse);
                if (exception != null) throw exception;
            }

            // DocuSign: Handle for PDF return types
            if (localVarResponse.ContentType != null && !localVarResponse.ContentType.ToLower().Contains("json"))
            {
                return new ApiResponse<UserInfoResponse>(localVarStatusCode, localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()), (UserInfoResponse)this.ApiClient.Deserialize(localVarResponse.RawBytes, typeof(UserInfoResponse)));
            }
            else
            {
                return new ApiResponse<UserInfoResponse>(localVarStatusCode, localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()), (UserInfoResponse)this.ApiClient.Deserialize(localVarResponse, typeof(UserInfoResponse)));
            }

        }

        #endregion UserInfo

        #region SignHashSessionInfo
        /// <summary>
        /// Provides signing session information for a Trust Service Provider. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="signHashSessionInfo">SignSessionInfoRequest object.</param>
        /// <returns>SignHashSessionInfoResponse</returns>
        public SignHashSessionInfoResponse SignHashSessionInfo(SignSessionInfoRequest signHashSessionInfo)
        {
            ApiResponse<SignHashSessionInfoResponse> localVarResponse = SignHashSessionInfoWithHttpInfo(signHashSessionInfo);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Provides signing session information for a Trust Service Provider. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="signHashSessionInfo">SignSessionInfoRequest object.</param>
        /// <returns>ApiResponse of (SignHashSessionInfoResponse)</returns>
        public ApiResponse<SignHashSessionInfoResponse> SignHashSessionInfoWithHttpInfo(SignSessionInfoRequest signHashSessionInfo)
        {
            var localVarPath = _defaultApiPath + "/signhashsessioninfo";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(this.ApiClient.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = { };
            string localVarHttpContentType = this.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = { "application/json" };
            string localVarHttpHeaderAccept = this.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (signHashSessionInfo != null && signHashSessionInfo.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.ApiClient.Serialize(signHashSessionInfo); // http body (model) parameter
            }
            else
            {
                localVarPostBody = signHashSessionInfo; // byte array
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.ApiClient.CallApi(localVarPath,
            Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SignHashSessionInfo", localVarResponse);
                if (exception != null) throw exception;
            }


            // DocuSign: Handle for PDF return types
            if (localVarResponse.ContentType != null && !localVarResponse.ContentType.ToLower().Contains("json"))
            {
                return new ApiResponse<SignHashSessionInfoResponse>(localVarStatusCode, localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()), (SignHashSessionInfoResponse)this.ApiClient.Deserialize(localVarResponse.RawBytes, typeof(SignHashSessionInfoResponse)));
            }
            else
            {
                return new ApiResponse<SignHashSessionInfoResponse>(localVarStatusCode, localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()), (SignHashSessionInfoResponse)this.ApiClient.Deserialize(localVarResponse, typeof(SignHashSessionInfoResponse)));
            }

        }

        #endregion SignHashSessionInfo

        #region CompleteSignHash
        /// <summary>
        /// Finalize the Trust Service Provider session with the signed Hash. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="completeSignRequest">CompleteSignRequest object.</param>
        /// <returns>CompleteSignHashResponse</returns>
        public CompleteSignHashResponse CompleteSignHash(CompleteSignRequest completeSignRequest)
        {
            ApiResponse<CompleteSignHashResponse> localVarResponse = CompleteSignHashWithHttpInfo(completeSignRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Finalize the Trust Service Provider session with the signed Hash. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="completeSignRequest">CompleteSignRequest object.</param>
        /// <returns>ApiResponse of (CompleteSignHashResponse)</returns>
        public ApiResponse<CompleteSignHashResponse> CompleteSignHashWithHttpInfo(CompleteSignRequest completeSignRequest)
        {
            var localVarPath = _defaultApiPath + "/completesignhash";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(this.ApiClient.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = { };
            string localVarHttpContentType = this.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = { "application/json" };
            string localVarHttpHeaderAccept = this.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (completeSignRequest != null && completeSignRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.ApiClient.Serialize(completeSignRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = completeSignRequest; // byte array
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.ApiClient.CallApi(localVarPath,
            Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CompleteSignHash", localVarResponse);
                if (exception != null) throw exception;
            }


            // DocuSign: Handle for PDF return types
            if (localVarResponse.ContentType != null && !localVarResponse.ContentType.ToLower().Contains("json"))
            {
                return new ApiResponse<CompleteSignHashResponse>(localVarStatusCode, localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()), (CompleteSignHashResponse)this.ApiClient.Deserialize(localVarResponse.RawBytes, typeof(CompleteSignHashResponse)));
            }
            else
            {
                return new ApiResponse<CompleteSignHashResponse>(localVarStatusCode, localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()), (CompleteSignHashResponse)this.ApiClient.Deserialize(localVarResponse, typeof(CompleteSignHashResponse)));
            }

        }
        #endregion CompleteSignHash

        #region SignDocumentSessionInfo
        /// <summary>
        /// Provides signing session information for a Trust Service Provider. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="signDocumentSessionInfo">SignSessionInfoRequest object.</param>
        /// <returns>SignHashSessionInfoResponse</returns>
        public SignHashSessionInfoResponse SignDocumentSessionInfo(SignSessionInfoRequest signDocumentSessionInfo)
        {
            ApiResponse<SignHashSessionInfoResponse> localVarResponse = SignDocumentSessionInfoWithHttpInfo(signDocumentSessionInfo);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Provides signing session information for a Trust Service Provider. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="signDocumentSessionInfo">SignSessionInfoRequest object.</param>
        /// <returns>ApiResponse of (SignHashSessionInfoResponse)</returns>
        public ApiResponse<SignHashSessionInfoResponse> SignDocumentSessionInfoWithHttpInfo(SignSessionInfoRequest signDocumentSessionInfo)
        {
            var localVarPath = _defaultApiPath + "/signdocumentsessioninfo";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(this.ApiClient.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = { };
            string localVarHttpContentType = this.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = { "application/json" };
            string localVarHttpHeaderAccept = this.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (signDocumentSessionInfo != null && signDocumentSessionInfo.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.ApiClient.Serialize(signDocumentSessionInfo); // http body (model) parameter
            }
            else
            {
                localVarPostBody = signDocumentSessionInfo; // byte array
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.ApiClient.CallApi(localVarPath,
            Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SignDocumentSessionInfo", localVarResponse);
                if (exception != null) throw exception;
            }


            // DocuSign: Handle for PDF return types
            if (localVarResponse.ContentType != null && !localVarResponse.ContentType.ToLower().Contains("json"))
            {
                return new ApiResponse<SignHashSessionInfoResponse>(localVarStatusCode, localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()), (SignHashSessionInfoResponse)this.ApiClient.Deserialize(localVarResponse.RawBytes, typeof(SignHashSessionInfoResponse)));
            }
            else
            {
                return new ApiResponse<SignHashSessionInfoResponse>(localVarStatusCode, localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()), (SignHashSessionInfoResponse)this.ApiClient.Deserialize(localVarResponse, typeof(SignHashSessionInfoResponse)));
            }

        }

        #endregion SignHashSessionInfo

        #region CompleteSignDocument
        /// <summary>
        /// Finalize the Trust Service Provider session with the signed Hash. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="completeSignRequest">CompleteSignRequest object.</param>
        /// <returns>CompleteSignHashResponse</returns>
        public CompleteSignHashResponse CompleteSignDocument(CompleteSignRequest completeSignRequest)
        {
            ApiResponse<CompleteSignHashResponse> localVarResponse = CompleteSignDocumentWithHttpInfo(completeSignRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Finalize the Trust Service Provider session with the signed Hash. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="completeSignRequest">CompleteSignRequest object.</param>
        /// <returns>ApiResponse of (CompleteSignHashResponse)</returns>
        public ApiResponse<CompleteSignHashResponse> CompleteSignDocumentWithHttpInfo(CompleteSignRequest completeSignRequest)
        {
            var localVarPath = _defaultApiPath + "/completesigndocument";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(this.ApiClient.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = { };
            string localVarHttpContentType = this.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = { "application/json" };
            string localVarHttpHeaderAccept = this.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (completeSignRequest != null && completeSignRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.ApiClient.Serialize(completeSignRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = completeSignRequest; // byte array
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.ApiClient.CallApi(localVarPath,
            Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CompleteSignDocument", localVarResponse);
                if (exception != null) throw exception;
            }


            // DocuSign: Handle for PDF return types
            if (localVarResponse.ContentType != null && !localVarResponse.ContentType.ToLower().Contains("json"))
            {
                return new ApiResponse<CompleteSignHashResponse>(localVarStatusCode, localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()), (CompleteSignHashResponse)this.ApiClient.Deserialize(localVarResponse.RawBytes, typeof(CompleteSignHashResponse)));
            }
            else
            {
                return new ApiResponse<CompleteSignHashResponse>(localVarStatusCode, localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()), (CompleteSignHashResponse)this.ApiClient.Deserialize(localVarResponse, typeof(CompleteSignHashResponse)));
            }

        }
        #endregion CompleteSignHash

        #region UpdateTransaction
        /// <summary>
        /// Report an error from the Trust Service Provider to DocuSign. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updateTransactionRequest">UpdateTransactionRequest object.</param>
        /// <returns>UpdateTransactionResponse</returns>
        public UpdateTransactionResponse UpdateTransaction(UpdateTransactionRequest updateTransactionRequest)
        {
            ApiResponse<UpdateTransactionResponse> localVarResponse = UpdateTransactionWithHttpInfo(updateTransactionRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Report an error from the Trust Service Provider to DocuSign. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updateTransactionRequest">UpdateTransactionRequest object.</param>
        /// <returns>ApiResponse of (UpdateTransactionResponse)</returns>
        public ApiResponse<UpdateTransactionResponse> UpdateTransactionWithHttpInfo(UpdateTransactionRequest updateTransactionRequest)
        {
            var localVarPath = _defaultApiPath + "/updatetransaction";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(this.ApiClient.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = { };
            string localVarHttpContentType = this.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = { "application/json" };
            string localVarHttpHeaderAccept = this.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (updateTransactionRequest != null && updateTransactionRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.ApiClient.Serialize(updateTransactionRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = updateTransactionRequest; // byte array
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.ApiClient.CallApi(localVarPath,
            Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("UpdateTransaction", localVarResponse);
                if (exception != null) throw exception;
            }


            // DocuSign: Handle for PDF return types
            if (localVarResponse.ContentType != null && !localVarResponse.ContentType.ToLower().Contains("json"))
            {
                return new ApiResponse<UpdateTransactionResponse>(localVarStatusCode, localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()), (UpdateTransactionResponse)this.ApiClient.Deserialize(localVarResponse.RawBytes, typeof(UpdateTransactionResponse)));
            }
            else
            {
                return new ApiResponse<UpdateTransactionResponse>(localVarStatusCode, localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()), (UpdateTransactionResponse)this.ApiClient.Deserialize(localVarResponse, typeof(UpdateTransactionResponse)));
            }

        }
        #endregion UpdateTransaction

        #endregion Synchronous Operations

        #region Asynchronous Operations
        #region UserInfo
        /// <summary>
        /// Provides user information for a Trust Service Provider.
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of UserInfoResponse</returns>
        public async System.Threading.Tasks.Task<UserInfoResponse> UserInfoAsync()
        {
            ApiResponse<UserInfoResponse> localVarResponse = await UserInfoAsyncWithHttpInfo();
            return localVarResponse.Data;

        }

        /// <summary>
        /// Provides user information for a Trust Service Provider.
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (UserInfoResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<UserInfoResponse>> UserInfoAsyncWithHttpInfo()
        {
            var localVarPath = _defaultApiPath + "/userinfo";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(this.ApiClient.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("UserInfo", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<UserInfoResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (UserInfoResponse)this.ApiClient.Deserialize(localVarResponse, typeof(UserInfoResponse)));

        }
        #endregion UserInfo

        #region SignHashSessionInfo
        /// <summary>
        /// Returns Account available seals for specified account. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="signHashSessionInfo">The external account number (int) or account ID Guid.</param>
        /// <returns>Task of SignHashSessionInfoResponse</returns>
        public async System.Threading.Tasks.Task<SignHashSessionInfoResponse> SignHashSessionInfoAsync(SignSessionInfoRequest signHashSessionInfo)
        {
            ApiResponse<SignHashSessionInfoResponse> localVarResponse = await SignHashSessionInfoAsyncWithHttpInfo(signHashSessionInfo);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Returns Account available seals for specified account. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="signHashSessionInfo">The external account number (int) or account ID Guid.</param>
        /// <returns>Task of ApiResponse (SignHashSessionInfoResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<SignHashSessionInfoResponse>> SignHashSessionInfoAsyncWithHttpInfo(SignSessionInfoRequest signHashSessionInfo)
        {
            var localVarPath = _defaultApiPath + "/signhashsessioninfo";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(this.ApiClient.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (signHashSessionInfo != null && signHashSessionInfo.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.ApiClient.Serialize(signHashSessionInfo); // http body (model) parameter
            }
            else
            {
                localVarPostBody = signHashSessionInfo; // byte array
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SignHashSessionInfo", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<SignHashSessionInfoResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (SignHashSessionInfoResponse) this.ApiClient.Deserialize(localVarResponse, typeof(SignHashSessionInfoResponse)));

        }
        #endregion SignHashSessionInfo
        
        #region CompleteSignHash
        /// <summary>
        /// Finalize the Trust Service Provider session with the signed Hash. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="completeSignRequest">CompleteSignRequest object.</param>
        /// <returns>CompleteSignHashResponse</returns>
        public async System.Threading.Tasks.Task<CompleteSignHashResponse> CompleteSignHashAsync(CompleteSignRequest completeSignRequest)
        {
            ApiResponse<CompleteSignHashResponse> localVarResponse = await CompleteSignHashAsyncWithHttpInfo(completeSignRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Finalize the Trust Service Provider session with the signed Hash. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="completeSignRequest">CompleteSignRequest object.</param>
        /// <returns>ApiResponse of (CompleteSignHashResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CompleteSignHashResponse>> CompleteSignHashAsyncWithHttpInfo(CompleteSignRequest completeSignRequest)
        {
            var localVarPath = _defaultApiPath + "/completesignhash";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(this.ApiClient.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = { };
            string localVarHttpContentType = this.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = { "application/json" };
            string localVarHttpHeaderAccept = this.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (completeSignRequest != null && completeSignRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.ApiClient.Serialize(completeSignRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = completeSignRequest; // byte array
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.ApiClient.CallApiAsync(localVarPath,
            Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CompleteSignHash", localVarResponse);
                if (exception != null) throw exception;
            }


            // DocuSign: Handle for PDF return types
            return new ApiResponse<CompleteSignHashResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CompleteSignHashResponse)this.ApiClient.Deserialize(localVarResponse, typeof(CompleteSignHashResponse)));
        }
        #endregion CompleteSignHash

        #region SignDocumentSessionInfo
        /// <summary>
        /// Returns Account available seals for specified account. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="signDocumentSessionInfo">The external account number (int) or account ID Guid.</param>
        /// <returns>Task of SignHashSessionInfoResponse</returns>
        public async System.Threading.Tasks.Task<SignHashSessionInfoResponse> SignDocumentSessionInfoAsync(SignSessionInfoRequest signDocumentSessionInfo)
        {
            ApiResponse<SignHashSessionInfoResponse> localVarResponse = await SignDocumentSessionInfoAsyncWithHttpInfo(signDocumentSessionInfo);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Returns Account available seals for specified account. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="signDocumentSessionInfo">The external account number (int) or account ID Guid.</param>
        /// <returns>Task of ApiResponse (SignHashSessionInfoResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<SignHashSessionInfoResponse>> SignDocumentSessionInfoAsyncWithHttpInfo(SignSessionInfoRequest signDocumentSessionInfo)
        {
            var localVarPath = _defaultApiPath + "/signdocumentsessioninfo";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(this.ApiClient.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (signDocumentSessionInfo != null && signDocumentSessionInfo.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.ApiClient.Serialize(signDocumentSessionInfo); // http body (model) parameter
            }
            else
            {
                localVarPostBody = signDocumentSessionInfo; // byte array
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("SignDocumentSessionInfo", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<SignHashSessionInfoResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (SignHashSessionInfoResponse)this.ApiClient.Deserialize(localVarResponse, typeof(SignHashSessionInfoResponse)));

        }
        #endregion SignDocumentSessionInfo

        #region CompleteSignDocument
        /// <summary>
        /// Finalize the Trust Service Provider session with the signed Hash. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="completeSignRequest">CompleteSignRequest object.</param>
        /// <returns>CompleteSignHashResponse</returns>
        public async System.Threading.Tasks.Task<CompleteSignHashResponse> CompleteSignDocumentAsync(CompleteSignRequest completeSignRequest)
        {
            ApiResponse<CompleteSignHashResponse> localVarResponse = await CompleteSignDocumentAsyncWithHttpInfo(completeSignRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Finalize the Trust Service Provider session with the signed Hash. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="completeSignRequest">CompleteSignRequest object.</param>
        /// <returns>ApiResponse of (CompleteSignHashResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CompleteSignHashResponse>> CompleteSignDocumentAsyncWithHttpInfo(CompleteSignRequest completeSignRequest)
        {
            var localVarPath = _defaultApiPath + "/completesigndocument";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(this.ApiClient.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes = { };
            string localVarHttpContentType = this.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts = { "application/json" };
            string localVarHttpHeaderAccept = this.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (completeSignRequest != null && completeSignRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.ApiClient.Serialize(completeSignRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = completeSignRequest; // byte array
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.ApiClient.CallApiAsync(localVarPath,
            Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CompleteSignDocument", localVarResponse);
                if (exception != null) throw exception;
            }


            // DocuSign: Handle for PDF return types
            return new ApiResponse<CompleteSignHashResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CompleteSignHashResponse)this.ApiClient.Deserialize(localVarResponse, typeof(CompleteSignHashResponse)));
        }
        #endregion CompleteSignDocument

        #region UpdateTransaction
        /// <summary>
        /// Report an error from the Trust Service Provider to DocuSign. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updateTransactionRequest">UpdateTransactionRequest object.</param>
        /// <returns>UpdateTransactionResponse</returns>
        public async System.Threading.Tasks.Task<UpdateTransactionResponse> UpdateTransactionAsync(UpdateTransactionRequest updateTransactionRequest)
        {
            ApiResponse<UpdateTransactionResponse> localVarResponse = await UpdateTransactionAsyncWithHttpInfo(updateTransactionRequest);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Report an error from the Trust Service Provider to DocuSign. 
        /// </summary>
        /// <exception cref="DocuSign.eSign.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updateTransactionRequest">UpdateTransactionRequest object.</param>
        /// <returns>ApiResponse of (UpdateTransactionResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<UpdateTransactionResponse>> UpdateTransactionAsyncWithHttpInfo(UpdateTransactionRequest updateTransactionRequest)
        {
            var localVarPath = _defaultApiPath + "/updatetransaction";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(this.ApiClient.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (updateTransactionRequest != null && updateTransactionRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.ApiClient.Serialize(updateTransactionRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = updateTransactionRequest; // byte array
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("UpdateTransaction", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<UpdateTransactionResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (UpdateTransactionResponse)this.ApiClient.Deserialize(localVarResponse, typeof(UpdateTransactionResponse)));

        }
        #endregion UpdateTransaction
        #endregion Asynchronous Operations

    }
}
