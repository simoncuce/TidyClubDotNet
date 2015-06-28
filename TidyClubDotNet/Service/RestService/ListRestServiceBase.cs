namespace TidyClubDotNet.Service.RestService
{
    using System.Collections.Generic;
    using System.Net;

    using Newtonsoft.Json;

    using RestSharp;

    using TidyClubDotNet.Authentication;
    using TidyClubDotNet.Model;
    using TidyClubDotNet.Service.RestService.Interface;

    public class ListServiceBase<TResponse> : ServiceBase<TResponse>, IListRestService<TResponse> where TResponse : ModelBase
    {
        public ListServiceBase(string url, ResponseToken token, string endpoint)
            : base(url, token, endpoint)
        {
        }

        public List<TResponse> List(int limit = 0, int offset = 0)
        {
            var request = this.GetRequest(this.Endpoint, Method.GET);

            if (limit > 0)
            {
                request.AddParameter("limit", limit);
            }

            if (offset > 0)
            {
                request.AddParameter("offset", offset);
            }

            var response = this.Client.Execute(request);

            var keyResponse = JsonConvert.DeserializeObject<List<TResponse>>(response.Content);

            this.ProcessResult(response, HttpStatusCode.OK);

            return keyResponse;
        }
    }
}
