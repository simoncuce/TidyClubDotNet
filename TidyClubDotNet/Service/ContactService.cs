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

    public class ContactService : ServiceBase<Contact>, IService<Contact>
    {

        private readonly ICreateRestService<Contact.ContactRequest, Contact.ContactResponse> createRestService;
        private readonly IListRestService<Contact.ContactResponse> listRestService;
        private readonly IGetRestService<Contact.ContactResponse> getRestService;
        private readonly IDeleteRestService<Contact.ContactResponse> deleteRestService;
        private readonly IUpdateRestService<Contact.ContactRequest, Contact.ContactResponse> updateRestService; 

        public ContactService(string url, ResponseToken token) : base(url, token, "contacts")
        {
            this.createRestService = new CreateServiceBase<Contact.ContactRequest, Contact.ContactResponse>(url, token, "contacts");
            this.listRestService = new ListServiceBase<Contact.ContactResponse>(url, token, "contacts");
            this.getRestService = new GetServiceBase<Contact.ContactResponse>(url, token, "contacts");
            this.deleteRestService = new DeleteServiceBase<Contact.ContactResponse>(url, token, "contacts");
            this.updateRestService = new UpdateServiceBase<Contact.ContactRequest, Contact.ContactResponse>(url, token, "contacts");
        }

        public List<Contact> List(string searchTerms, int limit = 0, int offset = 0, bool registered = false)
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

            request.AddParameter("registered", registered);

            if (searchTerms == string.Empty)
            {
                request.AddParameter("search_terms", searchTerms);
            }

            var response = this.Client.Execute(request);

            var keyResponse = JsonConvert.DeserializeObject<List<Contact.ContactResponse>>(response.Content);

            this.ProcessResult(response, HttpStatusCode.OK);

            return keyResponse.Select(item => new Contact().CreateFromResponse(item)).ToList();
        }

        public List<Contact> List(Group group, string searchTerms = "", int limit = 0, int offset = 0, bool registered = false)
        {
           CustomContract.Requires<ArgumentNullException>(group != null, "Group is null");
           CustomContract.Requires<ArgumentNullException>(group.Id > 0, "Id is 0 or less");
            
            var request = this.GetRequest("groups/" + group.Id + "/contacts", Method.GET);

            if (limit > 0)
            {
                request.AddParameter("limit", limit);
            }

            if (offset > 0)
            {
                request.AddParameter("offset", offset);
            }

            request.AddParameter("registered", registered);

            if (searchTerms == string.Empty)
            {
                request.AddParameter("search_terms", searchTerms);
            }

            var response = this.Client.Execute(request);

            var keyResponse = JsonConvert.DeserializeObject<List<Contact.ContactResponse>>(response.Content);

            this.ProcessResult(response, HttpStatusCode.OK);

            return keyResponse.Select(item => new Contact().CreateFromResponse(item)).ToList();
        }

        public Contact GetMe()
        {
            var request = this.GetRequest(this.Endpoint + "/me", Method.GET);

            var response = this.Client.Execute(request);

            var keyResponse = JsonConvert.DeserializeObject<Contact.ContactResponse>(response.Content);

            this.ProcessResult(response, HttpStatusCode.OK);

            return new Contact().CreateFromResponse(keyResponse);
        }

        public Contact Create(Contact item)
        {
            CustomContract.Requires<ArgumentNullException>(item != null, "Contact is null");
            CustomContract.Requires<ArgumentNullException>(
                !string.IsNullOrEmpty(item.FirstName),
                "First name is not set");

            return new Contact().CreateFromResponse(this.createRestService.Create(item.CreateRequest()));
        }

        public bool Delete(int id)
        {
            return this.deleteRestService.Delete(id);
        }

        public Contact Get(int id)
        {
            var response = this.getRestService.Get(id);

            return new Contact().CreateFromResponse(response);
        }

        public List<Contact> List(int limit = 0, int offset = 0)
        {
            return this.listRestService.List(limit, offset).Select(item => this.Get(item.Id)).ToList();
        }

        public bool Update(Contact item)
        {
            CustomContract.Requires<ArgumentNullException>(item != null, "Contact is null");
            CustomContract.Requires<ArgumentNullException>(
                !string.IsNullOrEmpty(item.FirstName),
                "First name is not set");

            return this.updateRestService.Update(item.CreateRequest());
        }
    }
}
