namespace TidyClubDotNet.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TidyClubDotNet.Authentication;
    using TidyClubDotNet.Misc;
    using TidyClubDotNet.Model;
    using TidyClubDotNet.Service.Interface;
    using TidyClubDotNet.Service.RestService;
    using TidyClubDotNet.Service.RestService.Interface;

    public class ExpenseService : IRead<Expense>, ICreate<Expense>
    {
        private readonly IListRestService<Expense.ExpenseResponse> listRestService;
        private readonly IGetRestService<Expense.ExpenseResponse> getRestService;
        private readonly ICreateRestService<Expense.ExpenseRequest, Expense.ExpenseResponse> createRestService;

        private readonly ContactService contactService;
        private readonly CategoryService categoryService;

        public ExpenseService(string url, ResponseToken token)
        {
            this.contactService = new ContactService(url, token);
            this.categoryService = new CategoryService(url, token);

            this.listRestService = new ListServiceBase<Expense.ExpenseResponse>(url, token, "expenses");
            this.getRestService = new GetServiceBase<Expense.ExpenseResponse>(url, token, "expenses");
            this.createRestService = new CreateServiceBase<Expense.ExpenseRequest, Expense.ExpenseResponse>(url, token, "expenses");
        }

        public Expense Create(Expense item)
        {
            CustomContract.Requires<ArgumentNullException>(item != null, "Item is not set");
            CustomContract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(item.Name), "Name is not set");
            CustomContract.Requires<ArgumentNullException>(item.Amount > 0, "Amount must be greater than Zero");
            CustomContract.Requires<ArgumentNullException>(item.Category != null, "Category is not set");
            CustomContract.Requires<ArgumentNullException>(item.Contacts.Count > 0, "There are not contacts");

            var response = this.createRestService.Create(item.CreateRequest());

            var newItem = new Expense().CreateFromResponse(response);

            foreach (var contact in response.Contacts)
            {
                newItem.Contacts.Add(this.contactService.Get(contact.Id)); //need to detail with the payment status
            }

            newItem.Category = this.categoryService.Get(response.Category);

            return newItem;
        }

        public List<Expense> List(int limit = 0, int offset = 0)
        {
            return this.listRestService.List(limit, offset).Select(item => this.Get(item.Id)).ToList();
        }

        public Expense Get(int id)
        {
            var response = this.getRestService.Get(id);

            var item = new Expense().CreateFromResponse(response);

            foreach (var contact in response.Contacts)
            {
                item.Contacts.Add(this.contactService.Get(contact.Id)); //need to detail with the payment status
            }

            item.Category = this.categoryService.Get(response.Category);

            return item;
        }
    }
}
