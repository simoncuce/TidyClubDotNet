namespace TidyClubDotNet.Model
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class Contact : ModelBase, IConversion<Contact, Contact.ContactResponse, Contact.ContactRequest>
    {
        public string FirstName { get; set; } 

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address1 { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }

        public DateTime? Birthday { get; set; }

        public string Gender { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Details { get; set; }

        public string NickName { get; set; }

        public string Company { get; set; }

        public bool Subscribed { get; set; }

        public string ProfileImage { get; set; }

        public List<CustomField> CustomFields { get; set; }

        public Contact CreateFromResponse(ContactResponse response)
        {
            return new Contact
                       {
                           Id = response.Id,
                           CreateAt = response.CreateAt,
                           FirstName = response.FirstName,
                           LastName = response.LastName,
                           Email = response.Email,
                           Address1 = response.Address1,
                           PhoneNumber = response.PhoneNumber,
                           City = response.City,
                           State = response.State,
                           Country = response.Country,
                           PostCode = response.PostCode,
                           Birthday = response.Birthday,
                           Gender = response.Gender,
                           Facebook = response.Facebook,
                           Twitter = response.Twitter,
                           Details = response.Details,
                           CustomFields = response.CustomFields,
                           NickName = response.NickName,
                           Company = response.Company,
                           Subscribed = response.Subscribed,
                           ProfileImage = response.ProfileImage
                       };
        }

        public new ContactRequest CreateRequest()
        {
            return new ContactRequest
                       {
                           Id = this.Id,
                           CreateAt = this.CreateAt,
                           FirstName = this.FirstName,
                           LastName = this.LastName,
                           Email = this.Email,
                           Address1 = this.Address1,
                           PhoneNumber = this.PhoneNumber,
                           City = this.City,
                           State = this.State,
                           Country = this.Country,
                           PostCode = this.PostCode,
                           Birthday = this.Birthday,
                           Gender = this.Gender,
                           Facebook = this.Facebook,
                           Twitter = this.Twitter,
                           Details = this.Details,
                           Company = this.Company,
                           CustomFields = this.CustomFields
                       };
        }

        public class ContactRequest : ModelBase
        {
            [JsonProperty(PropertyName = "first_name")]
            public string FirstName { get; set; } 

            [JsonProperty(PropertyName = "last_name")]
            public string LastName { get; set; }

            [JsonProperty(PropertyName = "email_address")]
            public string Email { get; set; }

            [JsonProperty(PropertyName = "address1")]
            public string Address1 { get; set; }

            [JsonProperty(PropertyName = "phone_number")]
            public string PhoneNumber { get; set; }

            [JsonProperty(PropertyName = "city")]
            public string City { get; set; }

            [JsonProperty(PropertyName = "state")]
            public string State { get; set; }

            [JsonProperty(PropertyName = "country")]
            public string Country { get; set; }

            [JsonProperty(PropertyName = "postcode")]
            public string PostCode { get; set; }

            [JsonProperty(PropertyName = "birthday")]
            public DateTime? Birthday { get; set; }

            [JsonProperty(PropertyName = "gender")]
            public string Gender { get; set; }

            [JsonProperty(PropertyName = "company")] //not in doc
            public string Company { get; set; }

            [JsonProperty(PropertyName = "facebook")]
            public string Facebook { get; set; }

            [JsonProperty(PropertyName = "twitter")]
            public string Twitter { get; set; }

            [JsonProperty(PropertyName = "details")]
            public string Details { get; set; }

            [JsonProperty(PropertyName = "custom_fields")]
            public List<CustomField> CustomFields { get; set; }
        }

        public class ContactResponse : ModelBase
        {
            [JsonProperty(PropertyName = "first_name")]
            public string FirstName { get; set; } 

            [JsonProperty(PropertyName = "last_name")]
            public string LastName { get; set; }

            [JsonProperty(PropertyName = "email_address")]
            public string Email { get; set; }

            [JsonProperty(PropertyName = "address1")]
            public string Address1 { get; set; }

            [JsonProperty(PropertyName = "phone_number")]
            public string PhoneNumber { get; set; }

            [JsonProperty(PropertyName = "city")]
            public string City { get; set; }

            [JsonProperty(PropertyName = "state")]
            public string State { get; set; }

            [JsonProperty(PropertyName = "country")]
            public string Country { get; set; }

            [JsonProperty(PropertyName = "postcode")]
            public string PostCode { get; set; }

            [JsonProperty(PropertyName = "birthday")]
            public DateTime? Birthday { get; set; }

            [JsonProperty(PropertyName = "gender")]
            public string Gender { get; set; }

            [JsonProperty(PropertyName = "facebook")]
            public string Facebook { get; set; }

            [JsonProperty(PropertyName = "twitter")]
            public string Twitter { get; set; }

            [JsonProperty(PropertyName = "nick_name")] //not in doc
            public string NickName { get; set; }

            [JsonProperty(PropertyName = "company")] //not in doc
            public string Company { get; set; }

            [JsonProperty(PropertyName = "subscribed")] //not in doc
            public bool Subscribed { get; set; }

            [JsonProperty(PropertyName = "profile_image")] //not in doc
            public string ProfileImage { get; set; }

            [JsonProperty(PropertyName = "details")]
            public string Details { get; set; }

            [JsonProperty(PropertyName = "custom_fields")]
            public List<CustomField> CustomFields { get; set; }
        }
    }
}
