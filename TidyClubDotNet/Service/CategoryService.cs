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

    public class CategoryService : IRead<Category>
    {
        private readonly IListRestService<Category> listService; 

        public CategoryService(string url, ResponseToken token) 
        {
            this.listService = new ListServiceBase<Category>(url, token, "categories");
        }

        public List<Category> List(int limit = 0, int offset = 0)
        {
            return this.listService.List(limit, offset);
        }

        public Category Get(int id)
        {
            CustomContract.Requires<ArgumentNullException>(id > 0, "Id is 0 or less");
            
            return this.List().Find(f => f.Id == id);
        }
    }
}
