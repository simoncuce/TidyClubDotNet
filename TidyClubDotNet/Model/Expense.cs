namespace TidyClubDotNet.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;

    public class Expense : ModelBase, IConversion<Expense, Expense.ExpenseResponse, Expense.ExpenseRequest>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime? DueDate { get; set; }

        public Category Category { get; set; }

        public List<Contact> Contacts { get; set; }

        public Expense CreateFromResponse(ExpenseResponse response)
        {
            return new Expense
                             {
                                 Id = response.Id,
                                 CreateAt = response.CreateAt,
                                 Name = response.Name,
                                 Amount = response.Amount,
                                 DueDate = response.DueDate,
                                 Category = new Category(),
                                 Contacts = new List<Contact>()
                             };
        }

        public new ExpenseRequest CreateRequest()
        {
            return new ExpenseRequest
                             {
                                 Id = this.Id,
                                 CreateAt = this.CreateAt,
                                 Name = this.Name,
                                 Description = this.Description,
                                 Amount = this.Amount,
                                 DueDate = this.DueDate,
                                 Category = this.Category.Id,
                                 Contacts = this.Contacts.Select(f => f.Id).ToArray()
                             };
        }

        public class ExpenseResponse : ModelBase
        {
            [JsonProperty(PropertyName = "due_date")]
            public DateTime? DueDate { get; set; }

            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "description")]
            public string Description { get; set; }

            [JsonProperty(PropertyName = "amount")]
            public decimal Amount { get; set; }

            [JsonProperty(PropertyName = "category_id")]
            public int Category { get; set; }

            [JsonProperty(PropertyName = "contacts")]
            public Deposit.ContactStatus[] Contacts { get; set; }
        }

        public class ExpenseRequest : ModelBase
        {
            [JsonProperty(PropertyName = "due_date")]
            public DateTime? DueDate { get; set; }

            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "description")]
            public string Description { get; set; }

            [JsonProperty(PropertyName = "amount")]
            public decimal Amount { get; set; }

            [JsonProperty(PropertyName = "category_id")]
            public int Category { get; set; }

            [JsonProperty(PropertyName = "contacts")]
            public int[] Contacts { get; set; }
        }
    }
}
