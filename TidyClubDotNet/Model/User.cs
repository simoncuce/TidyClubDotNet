namespace TidyClubDotNet.Model
{
    using Newtonsoft.Json;

    public class User : ModelBase, IConversion<User, User.UserResponse, User.UserRequest>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public User CreateFromResponse(User.UserResponse response)
        {
            return new User
                       {
                           Id = response.ContactId,
                           Email = this.Email,
                           FirstName = this.FirstName,
                           LastName = this.LastName,
                           Password = this.Password,
                           CreateAt = response.CreateAt
                       };
        }

        public new User.UserRequest CreateRequest()
        {
            return new UserRequest
                       {
                           CreateAt = this.CreateAt,
                           Id = this.Id,
                           Email = this.Email,
                           FirstName = this.FirstName,
                           LastName = this.LastName,
                           Password = this.Password
                       };
        }

        public class UserRequest : ModelBase
        {
            [JsonProperty(PropertyName = "first_name")]
            public string FirstName { get; set; }

            [JsonProperty(PropertyName = "last_name")]
            public string LastName { get; set; }

            [JsonProperty(PropertyName = "email")]
            public string Email { get; set; }

            [JsonProperty(PropertyName = "password")]
            public string Password { get; set; }
        }

        public class UserResponse : ModelBase
        {
            [JsonProperty(PropertyName = "contact_id")]
            public int ContactId { get; set; }
        }
    }
}
