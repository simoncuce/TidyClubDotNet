namespace TidyClubDotNet.Service.RestService
{
    using System;
    using System.Net;

    using Newtonsoft.Json;

    using RestSharp;

    using TidyClubDotNet.Authentication;
    using TidyClubDotNet.Misc;
    using TidyClubDotNet.Model;
    using TidyClubDotNet.Service.RestService.Interface;

    public class GetServiceBase<TResponse> : ServiceBase<TResponse>, IGetRestService<TResponse> where TResponse : ModelBase, new ()
    {
        public GetServiceBase(string url, ResponseToken token, string endpoint) : base(url, token, endpoint)
        {
        }

        public TResponse Get(int id)
        {
           CustomContract.Requires<ArgumentNullException>(id > 0, "Id is 0 or less");

            var request = this.GetRequest(this.Endpoint + "/" + id, Method.GET);

            var response = this.Client.Execute(request);

            var keyResponse = JsonConvert.DeserializeObject<TResponse>(response.Content);

            this.ProcessResult(response, HttpStatusCode.OK);

            return keyResponse;
        }
    }
}
