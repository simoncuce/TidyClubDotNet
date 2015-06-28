namespace TidyClubDotNet.Authentication
{
    using Newtonsoft.Json;

    public class PasswordCredentials : IAuthenticate
    {
        private readonly string clientId;

        private readonly string clientSecret;

        private readonly string username;

        private readonly string password;

        public PasswordCredentials(string clientId, string clientSecret, string userName, string password)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.username = userName;
            this.password = password;
        }

        [JsonProperty(PropertyName = "client_id")]
        public string ClientId
        {
            get
            {
                return this.clientId;
            }
        }

        [JsonProperty(PropertyName = "client_secret")]
        public string ClientSecret
        {
            get
            {
                return this.clientSecret;
            }
        }

        [JsonProperty(PropertyName = "username")]
        public string Username
        {
            get
            {
                return this.username;
            }
        }

        [JsonProperty(PropertyName = "password")]
        public string Password
        {
            get
            {
                return this.password;
            }
        }

        [JsonProperty(PropertyName = "grant_type")]
        public string GrantType
        {
            get
            {
                return "password";
            }
        }
    }
}