namespace TidyClubDotNet.Service
{
    using System;
    using System.Collections.Generic;

    using TidyClubDotNet.Authentication;
    using TidyClubDotNet.Misc;
    using TidyClubDotNet.Model;
    using TidyClubDotNet.Service.Interface;
    using TidyClubDotNet.Service.RestService;
    using TidyClubDotNet.Service.RestService.Interface;

    public class CustomFieldService : IService<CustomField>
    {
        private readonly ICreateRestService<CustomField, CustomField> createRestService;

        private readonly IListRestService<CustomField> listRestService;

        private readonly IGetRestService<CustomField> getRestService;

        private readonly IDeleteRestService<CustomField> deleteRestService;

        private readonly IUpdateRestService<CustomField, CustomField> updateRestService;

        public CustomFieldService(string url, ResponseToken token)
        {
            this.createRestService = new CreateServiceBase<CustomField, CustomField>(url, token, "custom_fields");
            this.listRestService = new ListServiceBase<CustomField>(url, token, "custom_fields");
            this.getRestService = new GetServiceBase<CustomField>(url, token, "custom_fields");
            this.deleteRestService = new DeleteServiceBase<CustomField>(url, token, "custom_fields");
            this.updateRestService = new UpdateServiceBase<CustomField, CustomField>(url, token, "custom_fields");
        }

        public bool Update(CustomField item)
        {
            CustomContract.Requires<ArgumentNullException>(item != null, "CustomField is null");
            CustomContract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(item.Title), "Title is not set");
            CustomContract.Requires<ArgumentNullException>(item.Id > 0, "Id is 0 or less");

            return this.updateRestService.Update(item);
        }

        public CustomField Create(CustomField item)
        {
            CustomContract.Requires<ArgumentNullException>(item != null, "CustomField is null");
            CustomContract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(item.Title), "Title is not set");

            return this.createRestService.Create(item);
        }

        public List<CustomField> List(int limit = 0, int offset = 0)
        {
            return this.listRestService.List(limit, offset);
        }

        public bool Delete(int id)
        {
            return this.deleteRestService.Delete(id);
        }

        public CustomField Get(int id)
        {
            return this.getRestService.Get(id);
        }
    }
}
