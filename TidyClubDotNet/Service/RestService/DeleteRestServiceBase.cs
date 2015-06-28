namespace TidyClubDotNet.Service.RestService
{
    using System;
    using System.Net;

    using RestSharp;

    using TidyClubDotNet.Authentication;
    using TidyClubDotNet.Misc;
    using TidyClubDotNet.Model;
    using TidyClubDotNet.Service.RestService.Interface;

    public class DeleteServiceBase<TReponse> : ServiceBase<TReponse>, IDeleteRestService<TReponse> where TReponse : ModelBase
    {
        public DeleteServiceBase(string url, ResponseToken token, string endpoint)
            : base(url, token, endpoint)
        {
        }

        public bool Delete(int id)
        {
           CustomContract.Requires<ArgumentNullException>(id > 0, "Id is 0 or less");

            var request = this.GetRequest(this.Endpoint + "/" + id, Method.DELETE);

            var response = this.Client.Execute(request);

            return this.ProcessResult(response, HttpStatusCode.OK);
        }
    }
}
