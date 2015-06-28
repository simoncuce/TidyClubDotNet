namespace TidyClubDotNet.Model
{
    using System.Collections.Generic;

    public class Club : ModelBase, IConversion<Club, Club.ClubResponse, Club>
    {
        public string Name { get; set; }

        public string DomainPrefix { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Information { get; set; }

        public string Website { get; set; }

        public string Email { get; set; } //missing from docs

        public List<Contact> PublicContacts { get; set; } //missing from docs

        public string Twitter { get; set; }

        public string LogoURL { get; set; } //missing from docs

        public string ImageURL { get; set; } //missing from docs

        public string Facebook { get; set; }

        public string TimeZone { get; set; }

        public Club CreateFromResponse(ClubResponse response)
        {
            var item = new Club
                           {
                               Id = response.Id,
                               Name = response.Name,
                               DomainPrefix = response.DomainPrefix,
                               Location = response.Location,
                               Address = response.Address,
                               City = response.City,
                               State = response.State,
                               Country = response.Country,
                               Phone = response.Phone,
                               Information = response.Information,
                               Website = response.Website,
                               Email = response.Email,
                               PublicContacts = new List<Contact>(),
                               Twitter = response.Twitter,
                               LogoURL = response.LogoURL,
                               ImageURL = response.ImageURL,
                               Facebook = response.Facebook,
                               TimeZone = response.TimeZone
                           };

            return item;
        }

        public new Club CreateRequest()
        {
            return this;
        }

        public class ClubResponse : ModelBase
        {
            public string Name { get; set; }

            public string DomainPrefix { get; set; }

            public string Location { get; set; }

            public string Address { get; set; }

            public string City { get; set; }

            public string State { get; set; }

            public string Country { get; set; }

            public string Phone { get; set; }

            public string Information { get; set; }

            public string Website { get; set; }

            public string Email { get; set; } //missing from docs

            public int[] PublicContacts { get; set; } //missing from docs

            public string Twitter { get; set; }

            public string LogoURL { get; set; } //missing from docs

            public string ImageURL { get; set; } //missing from docs

            public string Facebook { get; set; }

            public string TimeZone { get; set; }

        }
    }
}
