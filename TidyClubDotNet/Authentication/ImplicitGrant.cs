namespace TidyClubDotNet.Authentication
{
    using Newtonsoft.Json;

    public class ImplicitGrant : IAuthenticate
    {
        private readonly string clientId;

        private readonly string redirectUri;

        public ImplicitGrant(string clientId, string redirectUri)
        {
            this.clientId = clientId;
            this.redirectUri = redirectUri;
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
                return "token";
            }
        }
    }
}