namespace TidyClubDotNet
{
    using System;
    using System.Net;

    using RestSharp;

    using TidyClubDotNet.Authentication;
    using TidyClubDotNet.Misc;

    public class TidyClub
    {
        private readonly string url;

        public TidyClub(string domainPrefix)
        {
            this.url = string.Format("https://{0}.tidyclub.com/", domainPrefix);
        }

        public ServiceList AuthenticatePasswordCredentials(PasswordCredentials details)
        {
            var client = new RestClient(this.url);

            var request = new RestRequest("oauth/token", Method.POST)
                              {
                                  RequestFormat = DataFormat.Json,
                                  JsonSerializer =
                                      new RestSharpJsonNetSerializer()
                              };

            request.AddBody(details);

            var response = client.Execute<ResponseToken>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Error request");
            }

            return new ServiceList(this.url, response.Data);
        }

        public void AuthenticateImplicitGrant(ImplicitGrant details)
        {
            var client = new RestClient(this.url);
            
            var request = new RestRequest("oauth/authorize", Method.GET)
                              {
                                  RequestFormat = DataFormat.Json,
                                  JsonSerializer =
                                      new RestSharpJsonNetSerializer()
                              };

            request.AddQueryParameter("client_id", details.ClientId);
            request.AddQueryParameter("redirect_uri", ((ImplicitGrant)details).RedirectUri);
            request.AddQueryParameter("response_type", ((ImplicitGrant)details).GrantType);

            var response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Error request");
            }
        }

        public ServiceList AuthenticateImplicitGrant(ResponseToken details)
        {
             return new ServiceList(this.url, details);
        }

        public void AuthenticateAuthorize(Authorize details)
        {
            var client = new RestClient(this.url);

            var request = new RestRequest("oauth/authorize", Method.GET)
                              {
                                  RequestFormat = DataFormat.Json,
                                  JsonSerializer =
                                      new RestSharpJsonNetSerializer()
                              };

            request.AddQueryParameter("client_id", details.ClientId);
            request.AddQueryParameter("redirect_uri", ((Authorize)details).RedirectUri);
            request.AddQueryParameter("response_type", ((Authorize)details).GrantType);

            var response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Error request");
            }
        }

        public ServiceList AuthenticateImplicitGrant(Authorize details, string code)
        {
            var client = new RestClient(this.url);

            details.Code = code;

            var request = new RestRequest("oauth/token", Method.POST)
                              {
                                  RequestFormat = DataFormat.Json,
                                  JsonSerializer =
                                      new RestSharpJsonNetSerializer()
                              };

            request.AddBody(details);

            var newResponse = client.Execute<ResponseToken>(request);

            if (newResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Error request");
            }

            return new ServiceList(this.url, newResponse.Data);
        }
    }
}
