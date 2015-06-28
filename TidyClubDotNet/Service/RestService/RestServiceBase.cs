namespace TidyClubDotNet.Service.RestService
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;

    using RestSharp;

    using TidyClubDotNet.Authentication;
    using TidyClubDotNet.Misc;
    using TidyClubDotNet.Model;

    public class ServiceBase<TResponse> where TResponse : ModelBase
    {
        public readonly RestClient Client;

        public readonly ResponseToken Token;

        public readonly string Endpoint;

        public ServiceBase(string url, ResponseToken token, string endpoint)
        {
            this.Client = new RestClient(url + "api/v1/");
            this.Token = token;
            this.Endpoint = endpoint;
        }

        public void Requires<TException>(bool predicate, string message) where TException : Exception, new()
        {
            if (!predicate)
            {
                Debug.WriteLine(message);
                throw new TException();
            }
        }

        protected RestRequest GetRequest(string requestUrl, Method method)
        {
            var request = new RestRequest(requestUrl, method)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new RestSharpJsonNetSerializer()
            };

            request.AddHeader("Authorization", string.Format("Bearer {0}", this.Token.AccessToken));

            return request;
        }

        protected TResponse ProcessResult(IRestResponse<TResponse> response, HttpStatusCode expectedCode)
        {
            this.TestResponse(response, expectedCode);

            return response.Data;
        }

        protected TResponse ProcessResult(TResponse response, HttpStatusCode expectedCode)
        {
            return response;
        }

        protected List<TResponse> ProcessResult(IRestResponse<List<TResponse>> response, HttpStatusCode expectedCode)
        {
            this.TestResponse(response, expectedCode);

            return response.Data;
        }

        protected List<TResponse> ProcessResult(List<TResponse> response, HttpStatusCode expectedCode)
        {
            return response;
        }

        protected bool ProcessResult(IRestResponse response, HttpStatusCode expectedCode)
        {
            this.TestResponse(response, expectedCode);

            return true;
        }

        protected void TestResponse(IRestResponse response, HttpStatusCode expectedCode)
        {
            if (response.ErrorMessage != null)
            {
                throw new Exception(response.ErrorMessage);
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return;
            }

            if (response.StatusCode != expectedCode)
            {
                if (response.StatusCode.ToString() == "422") 
                {
                    throw new Exception(string.Format("Error from Service : StatusCode is {0}, it should be {1}", response.StatusCode, expectedCode), new Exception(response.Content));
                }

                throw new Exception(string.Format("Error from Service : StatusCode is {0}, it should be {1}", response.StatusCode, expectedCode));
            }
        }
    }
}
