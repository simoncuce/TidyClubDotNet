namespace TidyClubDotNet.Authentication
{
    using Newtonsoft.Json;

    public class Authorize : IAuthenticate
    {
        private readonly string clientId;

        private readonly string redirectUri;

        private readonly string clientSecret;

        public Authorize(string clientId, string redirectUri, string clientSecret)
        {
            this.clientId = clientId;
            this.redirectUri = redirectUri;
            this.clientSecret = clientSecret;
        }

        [JsonProperty(PropertyName = "code")]
        public string Code
        {
            get; set;
        }

        [JsonProperty(PropertyName = "client_secret")]
        public string ClientSecret
        {
            get
            {
                return this.clientSecret;
            }
        }

        [JsonProperty(PropertyName = "client_id")]
        public string ClientId
        {
            get
            {
                return this.clientId;
            }
        }

        [JsonProperty(PropertyName = "redirect_uri")]
        public string RedirectUri
        {
            get
            {
                return this.redirectUri;
            }
        }

        [JsonProperty(PropertyName = "grant_type")]
        public string GrantType
        {
            get
            {
                return "code";
            }
        }
    }
}