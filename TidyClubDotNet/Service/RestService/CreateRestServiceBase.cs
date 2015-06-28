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

    public class CreateServiceBase<TRequest, TResponse> : ServiceBase<TResponse>,
                                                          ICreateRestService<TRequest, TResponse>
        where TResponse : ModelBase, new()
    {
        public CreateServiceBase(string url, ResponseToken token, string endpoint)
            : base(url, token, endpoint)
        {
        }

        public TResponse Create(TRequest item)
        {
            CustomContract.Requires<ArgumentNullException>(item != null, "Item is null");

            var request = this.GetRequest(this.Endpoint, Method.POST);

            request.AddBody(item);

            var response = this.Client.Execute(request);

            var keyResponse = JsonConvert.DeserializeObject<TResponse>(response.Content);

            this.ProcessResult(response, HttpStatusCode.Created);

            return keyResponse;
        }
    }
}
