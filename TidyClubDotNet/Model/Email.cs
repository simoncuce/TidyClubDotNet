namespace TidyClubDotNet.Model
{
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;

    public class Email : ModelBase, IConversion<Email, Email.EmailResponse, Email.EmailRequest>
    {
        public new string Id { get; set; } //the object in the spec is a string

        public string Subject { get; set; }

        public string Body { get; set; }

        public List<Contact> Contacts { get; set; }

        public string ScheduledAt { get; set; } //not in doc

        public Email CreateFromResponse(EmailResponse response)
        {
            return new Email()
                       {
                           Body = response.Body,
                           Id = response.Id,
                           CreateAt = response.CreateAt,
                           Subject = response.Subject,
                           ScheduledAt = response.ScheduledAt,
                           Contacts = new List<Contact>()
                       };
        }

        public new EmailRequest CreateRequest()
        {
            return new EmailRequest()
                       {
                           Body = this.Body,
                           Id = this.Id,
                           CreateAt = this.CreateAt,
                           Subject = this.Subject,
                           ScheduledAt = this.ScheduledAt,
                           Contacts = this.Contacts.Select(f => f.Id).ToArray()
                       };
        }

        public class EmailResponse : ModelBase
        {
            [JsonProperty(PropertyName = "id")]
            public new string Id { get; set; }

            [JsonProperty(PropertyName = "subject")]
            public string Subject { get; set; }

            [JsonProperty(PropertyName = "body")]
            public string Body { get; set; }

            [JsonProperty(PropertyName = "scheduled_at")]
            public string ScheduledAt { get; set; }
        }

        public class EmailRequest : ModelBase
        {
            [JsonProperty(PropertyName = "id")]
            public new string Id { get; set; }

            [JsonProperty(PropertyName = "subject")]
            public string Subject { get; set; }

            [JsonProperty(PropertyName = "body")]
            public string Body { get; set; }

            [JsonProperty(PropertyName = "contacts")]
            public int[] Contacts { get; set; }

            [JsonProperty(PropertyName = "scheduled_at")]
            public string ScheduledAt { get; set; }
        }
    }
}