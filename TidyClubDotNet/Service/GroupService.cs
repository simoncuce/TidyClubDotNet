namespace TidyClubDotNet.Service
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using RestSharp;

    using TidyClubDotNet.Authentication;
    using TidyClubDotNet.Misc;
    using TidyClubDotNet.Model;
    using TidyClubDotNet.Service.Interface;
    using TidyClubDotNet.Service.RestService;
    using TidyClubDotNet.Service.RestService.Interface;

    public class GroupService : ServiceBase<Group>,  IService<Group>
    {
        private readonly ICreateRestService<Group, Group> createRestService;
        private readonly IListRestService<Group> listRestService;
        private readonly IGetRestService<Group> getRestService;
        private readonly IDeleteRestService<Group> deleteRestService;
        private readonly IUpdateRestService<Group, Group> updateRestService; 

        public GroupService(string url, ResponseToken token) : base(url, token, "groups")
        {
            this.createRestService = new CreateServiceBase<Group, Group>(url, token, "groups");
            this.listRestService = new ListServiceBase<Group>(url, token, "groups");
            this.getRestService = new GetServiceBase<Group>(url, token, "groups");
            this.deleteRestService = new DeleteServiceBase<Group>(url, token, "groups");
            this.updateRestService = new UpdateServiceBase<Group, Group>(url, token, "groups");
        }

        public List<Group> List(string searchTerms, int limit = 0, int offset = 0)
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

            request.AddParameter("search_terms", searchTerms);

            var response = this.Client.Execute<List<Group>>(request);

            return this.ProcessResult(response, HttpStatusCode.OK);
        }

        public List<Group> List(Contact contact, int limit = 0, int offset = 0)
        {
            var request = this.GetRequest("contacts/" + contact.Id + "/" + this.Endpoint, Method.GET);

            if (limit > 0)
            {
                request.AddParameter("limit", limit);
            }

            if (offset > 0)
            {
                request.AddParameter("offset", offset);
            }

            var response = this.Client.Execute<List<Group>>(request);

            return this.ProcessResult(response, HttpStatusCode.OK);
        }

        public Group Create(Group group)
        {
            CustomContract.Requires<ArgumentNullException>(group != null, "Group is null");
            CustomContract.Requires<ArgumentNullException>(
                !string.IsNullOrEmpty(group.Label),
                "Label is a required field");

            return this.createRestService.Create(group);
        }

        public bool Update(Group group)
        {
            CustomContract.Requires<ArgumentNullException>(group != null, "Group is null");
            CustomContract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(group.Label), "Label is a required field");

            return this.updateRestService.Update(group);
        }

        public bool AddContact(Contact contact, Group group)
        {
            CustomContract.Requires<ArgumentNullException>(group != null, "Group is null");
            CustomContract.Requires<ArgumentNullException>(group.Id > 0, "Group Id is 0 or less");

            CustomContract.Requires<ArgumentNullException>(contact != null, "Contact is null");
            CustomContract.Requires<ArgumentNullException>(contact.Id > 0, "Contact Id is 0 or less");

            var request = this.GetRequest(this.Endpoint + "/" + group.Id + "/contacts/" + contact.Id, Method.PUT);

            var response = this.Client.Execute(request);

            return this.ProcessResult(response, HttpStatusCode.NoContent);
        }

        public bool DeleteContact(Contact contact, Group group)
        {
           CustomContract.Requires<ArgumentNullException>(group != null, "Group is null");
           CustomContract.Requires<ArgumentNullException>(group.Id > 0, "Group Id is 0 or less");

           CustomContract.Requires<ArgumentNullException>(contact != null, "Contact is null");
           CustomContract.Requires<ArgumentNullException>(contact.Id > 0, "Contact Id is 0 or less");

            var request = this.GetRequest(this.Endpoint + "/" + group.Id + "/contacts/" + contact.Id, Method.DELETE);

            var response = this.Client.Execute(request);

            return this.ProcessResult(response, HttpStatusCode.NoContent);
        }

        public List<Group> List(int limit = 0, int offset = 0)
        {
            return this.listRestService.List(limit, offset);
        }

        public bool Delete(int id)
        {
            return this.deleteRestService.Delete(id);
        }

        public Group Get(int id)
        {
            return this.getRestService.Get(id);
        }
    }
}
