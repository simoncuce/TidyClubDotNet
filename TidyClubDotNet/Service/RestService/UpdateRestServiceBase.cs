namespace TidyClubDotNet.Service.RestService
{
    using System;
    using System.Net;

    using RestSharp;

    using TidyClubDotNet.Authentication;
    using TidyClubDotNet.Misc;
    using TidyClubDotNet.Model;
    using TidyClubDotNet.Service.RestService.Interface;

    public class UpdateServiceBase<TRequest, TResponse> : ServiceBase<TResponse>,
                                                          IUpdateRestService<TRequest, TResponse>
        where TResponse : ModelBase where TRequest : ModelBase
    {
        public UpdateServiceBase(string url, ResponseToken token, string endpoint)
            : base(url, token, endpoint)
        {
        }

        public bool Update(TRequest item)
        {
            CustomContract.Requires<ArgumentNullException>(item != null, "Item is null");
            CustomContract.Requires<ArgumentNullException>(item != null && item.Id > 0, "Id is 0 or less");

            if (item != null)
            {
                var request = this.GetRequest(this.Endpoint + "/" + item.Id, Method.PUT);

                request.AddBody(item);

                var response = this.Client.Execute(request);

                return this.ProcessResult(response, HttpStatusCode.OK);
            }

            return false;
        }
    }
}
