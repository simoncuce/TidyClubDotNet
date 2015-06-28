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

    public class InvoiceService : IRead<Invoice>
    {
        private readonly ICreateRestService<Invoice.InvoiceRequest, Invoice.InvoiceResponse> createRestService;
        private readonly IListRestService<Invoice.InvoiceResponse> listRestService;
        private readonly IGetRestService<Invoice.InvoiceResponse> getRestService;

        private readonly ContactService contactService;
        private readonly CategoryService categoryService;

        public InvoiceService(string url, ResponseToken token)
        {
            this.contactService = new ContactService(url, token);
            this.categoryService = new CategoryService(url, token);

            this.createRestService = new CreateServiceBase<Invoice.InvoiceRequest, Invoice.InvoiceResponse>(url, token, "invoices");
            this.listRestService = new ListServiceBase<Invoice.InvoiceResponse>(url, token, "invoices");
            this.getRestService = new GetServiceBase<Invoice.InvoiceResponse>(url, token, "invoices");
        }

        public Invoice Create(Invoice item)
        {
           CustomContract.Requires<ArgumentNullException>(item != null, "Item is not set");
           CustomContract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(item.Name), "Name is not set");
           CustomContract.Requires<ArgumentNullException>(item.DueDate != null, "Due date is not set");
           CustomContract.Requires<ArgumentNullException>(item.Amount > 0, "Amount must be greater than Zero");
           CustomContract.Requires<ArgumentNullException>(item.Category != null, "Category is not set");
           CustomContract.Requires<ArgumentNullException>(item.Contacts.Count > 0, "There are not contacts");

           var response = this.createRestService.Create(item.CreateRequest());

           var newItem = new Invoice().CreateFromResponse(response);

           foreach (var contact in response.Contacts)
           {
               newItem.Contacts.Add(this.contactService.Get(contact.Id)); //need to detail with the payment status
           }

           newItem.Category = this.categoryService.Get(response.Category);

           return newItem;
        }

        public List<Invoice> List(int limit = 0, int offset = 0)
        {
            return this.listRestService.List(limit, offset).Select(item => this.Get(item.Id)).ToList();
        }

        public Invoice Get(int id)
        {
            var response = this.getRestService.Get(id);

            var item = new Invoice().CreateFromResponse(response);

            foreach (var contact in response.Contacts)
            {
                item.Contacts.Add(this.contactService.Get(contact.Id)); //need to detail with the payment status
            }

            item.Category = this.categoryService.Get(response.Category);

            return item;
        }
    }
}
