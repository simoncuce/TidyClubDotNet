namespace TidyClubDotNet.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using RestSharp;

    using TidyClubDotNet.Authentication;
    using TidyClubDotNet.Misc;
    using TidyClubDotNet.Model;
    using TidyClubDotNet.Service.Interface;
    using TidyClubDotNet.Service.RestService;
    using TidyClubDotNet.Service.RestService.Interface;

    public class TaskService : ServiceBase<Task>, IService<Task>
    {
        private readonly ICreateRestService<Task.TaskRequest, Task.TaskResponse> createRestService;

        private readonly IListRestService<Task.TaskResponse> listRestService;

        private readonly IGetRestService<Task.TaskResponse> getRestService;

        private readonly IDeleteRestService<Task.TaskResponse> deleteRestService;

        private readonly IUpdateRestService<Task.TaskRequest, Task.TaskResponse> updateRestService;

        private readonly ContactService contactService;

        private readonly CategoryService categoryService;

        public TaskService(string url, ResponseToken token)
            : base(url, token, "tasks")
        {
            this.contactService = new ContactService(url, token);
            this.categoryService = new CategoryService(url, token);

            this.createRestService = new CreateServiceBase<Task.TaskRequest, Task.TaskResponse>(url, token, "tasks");
            this.listRestService = new ListServiceBase<Task.TaskResponse>(url, token, "tasks");
            this.getRestService = new GetServiceBase<Task.TaskResponse>(url, token, "tasks");
            this.deleteRestService = new DeleteServiceBase<Task.TaskResponse>(url, token, "tasks");
            this.updateRestService = new UpdateServiceBase<Task.TaskRequest, Task.TaskResponse>(url, token, "tasks");
        }

        public bool Update(Task item)
        {
            CustomContract.Requires<ArgumentNullException>(item != null, "Task is null");
            CustomContract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(item.Title), "Title is not set");
            CustomContract.Requires<ArgumentNullException>(item.DueDate != null, "Task is null");
            CustomContract.Requires<ArgumentNullException>(item.Contact != null, "Task is null");
            CustomContract.Requires<ArgumentNullException>(item.Category != null, "Task is null");

            return this.updateRestService.Update(item.CreateRequest());
        }

        public Task Create(Task item)
        {
            CustomContract.Requires<ArgumentNullException>(item != null, "Task is null");
            CustomContract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(item.Title), "Title is not set");
            CustomContract.Requires<ArgumentNullException>(item.DueDate != null, "Task is null");
            CustomContract.Requires<ArgumentNullException>(item.Contact != null, "Task is null");
            CustomContract.Requires<ArgumentNullException>(item.Category != null, "Task is null");

            var response = this.createRestService.Create(item.CreateRequest());

            var newItem = new Task().CreateFromResponse(response);

            newItem.Contact = this.contactService.Get(response.Contact);

            newItem.Category = this.categoryService.Get(response.Category);

            return newItem;
        }

        public List<Task> List(Contact contact)
        {
            CustomContract.Requires<ArgumentNullException>(contact != null, "Item is null");
            CustomContract.Requires<ArgumentNullException>(contact.Id > 0, "Id is 0 or less");

            var request = this.GetRequest("contacts/" + contact.Id + "/" + this.Endpoint, Method.GET);

            var response = this.Client.Execute<List<Task>>(request);

            return this.ProcessResult(response, HttpStatusCode.OK);
        }

        public List<Task> List(int limit = 0, int offset = 0)
        {
            return this.listRestService.List(limit, offset).Select(item => this.Get(item.Id)).ToList();
        }

        public bool Delete(int id)
        {
            return this.deleteRestService.Delete(id);
        }

        public Task Get(int id)
        {
            var response = this.getRestService.Get(id);

            var item = new Task().CreateFromResponse(response);

            item.Contact = this.contactService.Get(response.Contact);

            item.Category = this.categoryService.Get(response.Category);

            return item;
        }
    }
}
