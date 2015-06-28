namespace TidyClubDotNet.Model
{
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;

    public class Deposit : ModelBase, IConversion<Deposit, Deposit.DepositResponse, Deposit.DepositRequest>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public Category Category { get; set; }

        public List<Contact> Contacts { get; set; }

        public Deposit CreateFromResponse(DepositResponse depositResponse)
        {
            var result = new Deposit
                             {
                                 Id = depositResponse.Id,
                                 CreateAt = depositResponse.CreateAt,
                                 Name = depositResponse.Name,
                                 Amount = depositResponse.Amount,
                                 Category = new Category(),
                                 Contacts = new List<Contact>()
                             };

            return result;
        }

        public new DepositRequest CreateRequest()
        {
            var result = new DepositRequest
                             {
                                 Id = this.Id,
                                 CreateAt = this.CreateAt,
                                 Name = this.Name,
                                 Description = this.Description,
                                 Amount = this.Amount,
                                 Category = this.Category.Id,
                                 Contacts = this.Contacts.Select(f => f.Id).ToArray()
                             };

            return result;
        }

        public class DepositRequest : ModelBase
        {
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

        public class DepositResponse : ModelBase
        {
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "description")]
            public string Description { get; set; }

            [JsonProperty(PropertyName = "amount")]
            public decimal Amount { get; set; }

            [JsonProperty(PropertyName = "category_id")]
            public int Category { get; set; }

            [JsonProperty(PropertyName = "contacts")]
            public ContactStatus[] Contacts { get; set; }
        }

        public class ContactStatus
        {
            [JsonProperty(PropertyName = "contact_id")]
            public int Id { get; set; }

            [JsonProperty(PropertyName = "paid")]
            public bool Paid { get; set; }
        }
    }
}
