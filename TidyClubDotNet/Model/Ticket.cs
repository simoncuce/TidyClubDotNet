namespace TidyClubDotNet.Model
{
    using System;

    using Newtonsoft.Json;

    public class Ticket : ModelBase, IConversion<Ticket, Ticket.TicketResponse, Ticket.TicketRequest>
    {
        public string Name { get; set; }

        public decimal Amount { get; set; }

        public int InitialQuantity { get; set; }

        public int MaxQuantity { get; set; }

        public DateTime? SalesEnd { get; set; }

        public int QuantitySold { get; set; }

        public bool MemberOnly { get; set; }

        public int MembershipLevel { get; set; }

        public Ticket CreateFromResponse(Ticket.TicketResponse response)
        {
            return new Ticket
                       {
                           Id = response.Id,
                           CreateAt = response.CreateAt,
                           Name = response.Name,
                           Amount = response.Amount,
                           InitialQuantity = response.InitialQuantity.HasValue? response.InitialQuantity.Value : 0,
                           MaxQuantity = response.MaxQuantity,
                           SalesEnd = response.SalesEnd,
                           QuantitySold = response.QuantitySold,
                           MemberOnly = response.MemberOnly,
                           MembershipLevel = response.MembershipLevel.HasValue ? response.MembershipLevel.Value : 0
                       };
        }

        public new Ticket.TicketRequest CreateRequest()
        {
            return new TicketRequest
                       {
                           Id = this.Id,
                           CreateAt = this.CreateAt,
                           Name = this.Name,
                           Amount = this.Amount,
                           InitialQuantity = this.InitialQuantity,
                           MaxQuantity = this.MaxQuantity,
                           SalesEnd = this.SalesEnd,
                       };
        }

        public class TicketResponse : ModelBase
        {
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "amount")]
            public decimal Amount { get; set; }

            [JsonProperty(PropertyName = "initial_quantity")]
            public int? InitialQuantity { get; set; }

            [JsonProperty(PropertyName = "maximum_purchase")]
            public int MaxQuantity { get; set; }

            [JsonProperty(PropertyName = "quantity_sold")]
            public int QuantitySold { get; set; }

            [JsonProperty(PropertyName = "members_only")]
            public bool MemberOnly { get; set; }

            [JsonProperty(PropertyName = "membership_level_id")]
            public int? MembershipLevel { get; set; }

            [JsonProperty(PropertyName = "sales_end")]
            public DateTime? SalesEnd { get; set; }
        }

        public class TicketRequest : ModelBase
        {
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "amount")]
            public decimal Amount { get; set; }

            [JsonProperty(PropertyName = "initial_quantity")]
            public int InitialQuantity { get; set; }

            [JsonProperty(PropertyName = "maximum_purchase")]
            public int MaxQuantity { get; set; }

            [JsonProperty(PropertyName = "sales_end")]
            public DateTime? SalesEnd { get; set; }
        }
    }
}
