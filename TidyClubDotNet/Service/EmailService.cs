namespace TidyClubDotNet.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using Newtonsoft.Json;

    using RestSharp;

    using TidyClubDotNet.Authentication;
    using TidyClubDotNet.Misc;
    using TidyClubDotNet.Model;
    using TidyClubDotNet.Service.Interface;
    using TidyClubDotNet.Service.RestService;
    using TidyClubDotNet.Service.RestService.Interface;

    public class EmailService : ServiceBase<Email.EmailResponse>, IRead<Email>
    {
        private readonly ICreateRestService<Email.EmailRequest, Email.EmailResponse> createRestService;
        private readonly IListRestService<Email.EmailResponse> listRestService;
        private readonly IGetRestService<Email.EmailResponse> getRestService;

        public EmailService(string url, ResponseToken token)
            : base(url, token, "emails")
        {
            this.createRestService = new CreateServiceBase<Email.EmailRequest, Email.EmailResponse>(url, token, "emails");
            this.listRestService = new ListServiceBase<Email.EmailResponse>(url, token, "emails");
            this.getRestService = new GetServiceBase<Email.EmailResponse>(url, token, "emails");
        }

        public Email Create(Email item)
        {
            CustomContract.Requires<ArgumentNullException>(item != null, "Item is null");
            CustomContract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(item.Subject), "Subject is a required field");
            CustomContract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(item.Body), "Body is a required field");
            CustomContract.Requires<ArgumentNullException>(item.Contacts.Count != 0, "There are no contacts");

            var response = this.createRestService.Create(item.CreateRequest());

            var newItem = new Email().CreateFromResponse(response);

            return newItem;
        }

        public List<Email> List(int limit = 0, int offset = 0)
        {
            return this.listRestService.List(limit, offset).Select(item => this.Get(item.Id)).ToList();
        }

        public Email Get(int id)
        {
            var response = this.getRestService.Get(id);

            var item = new Email().CreateFromResponse(response);

            return item;
        }

        public Email Get(string id)
        {
            var request = this.GetRequest(this.Endpoint + "/" + id, Method.GET);

            var response = this.Client.Execute(request);

            var keyResponse = JsonConvert.DeserializeObject<Email.EmailResponse>(response.Content);

            this.ProcessResult(response, HttpStatusCode.OK);

            var item = new Email().CreateFromResponse(keyResponse);

            return item;
        }
    }
}
