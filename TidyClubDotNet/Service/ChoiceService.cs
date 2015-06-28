namespace TidyClubDotNet.Service
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using RestSharp;

    using TidyClubDotNet.Authentication;
    using TidyClubDotNet.Misc;
    using TidyClubDotNet.Model;
    using TidyClubDotNet.Service.RestService;

    public class ChoiceService : ServiceBase<Choice>
    {
        public ChoiceService(string url, ResponseToken token)
            : base(url, token, "custom_fields")
        {
        }

        public List<Choice> List(CustomField item)
        {
           CustomContract.Requires<ArgumentNullException>(item != null, "CustomField is null");
           CustomContract.Requires<ArgumentNullException>(item.Id > 0, "Custom Field Id is not set");
            
            var request = this.GetRequest(this.Endpoint + "/" + item.Id + "/choices", Method.GET);

            var response = this.Client.Execute<List<Choice>>(request);

            return this.ProcessResult(response, HttpStatusCode.OK);
        }

        public Choice Get(CustomField item, Choice choice)
        {
            CustomContract.Requires<ArgumentNullException>(item != null, "CustomField is null");
            CustomContract.Requires<ArgumentNullException>(item.Id > 0, "Custom Field Id is not set");

            CustomContract.Requires<ArgumentNullException>(choice != null, "Choice is null");
            CustomContract.Requires<ArgumentNullException>(choice.Id > 0, "Choice Id is not set");

            var request = this.GetRequest(this.Endpoint + "/" + item.Id + "/choice/" + choice.Id, Method.GET);

            var response = this.Client.Execute<Choice>(request);

            return this.ProcessResult(response, HttpStatusCode.OK);
        }

        public Choice Create(CustomField item, Choice choice)
        {
            CustomContract.Requires<ArgumentNullException>(item != null, "CustomField is null");
            CustomContract.Requires<ArgumentNullException>(item.Id > 0, "Choice Id is not set");

            CustomContract.Requires<ArgumentNullException>(choice != null, "Choice is null");
            CustomContract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(choice.Title), "Title is not set");

            var request = this.GetRequest(this.Endpoint, Method.POST);

            request.AddBody(item);

            var response = this.Client.Execute<Choice>(request);

            return this.ProcessResult(response, HttpStatusCode.Created);
        }

        public bool Update(CustomField item, Choice choice)
        {
           CustomContract.Requires<ArgumentNullException>(item != null, "CustomField is null");
           CustomContract.Requires<ArgumentNullException>(item.Id > 0, "Choice Id is not set");

           CustomContract.Requires<ArgumentNullException>(choice != null, "Choice is null");
           CustomContract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(choice.Title), "Title is not set");

            var request = this.GetRequest(this.Endpoint + "/" + item.Id + "/choices/" + choice.Id, Method.PUT);

            request.AddBody(choice);

            var response = this.Client.Execute(request);

            return this.ProcessResult(response, HttpStatusCode.Created);
        }

        public bool Delete(CustomField item, int id)
        {
            CustomContract.Requires<ArgumentNullException>(item != null, "CustomField is null");
            CustomContract.Requires<ArgumentNullException>(item.Id > 0, "Custom Field Id is not set");

            CustomContract.Requires<ArgumentNullException>(id > 0, "Choice Id is 0 or less");

            var request = this.GetRequest(this.Endpoint + "/" + item.Id + "/choices/" + id, Method.DELETE);

            var response = this.Client.Execute(request);

            return this.ProcessResult(response, HttpStatusCode.OK);
        }
    }
}
