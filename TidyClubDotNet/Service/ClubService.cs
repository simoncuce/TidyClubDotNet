namespace TidyClubDotNet.Service
{
    using System.Net;

    using Newtonsoft.Json;

    using RestSharp;

    using TidyClubDotNet.Authentication;
    using TidyClubDotNet.Model;
    using TidyClubDotNet.Service.RestService;

    public class ClubService : ServiceBase<Club.ClubResponse>
    {
        private readonly ContactService contactService;

        public ClubService(string url, ResponseToken token)
            : base(url, token, "club")
        {
            this.contactService = new ContactService(url, token);
        }

        public Club Get()
        {
            var request = this.GetRequest(this.Endpoint, Method.GET);

            var response = this.Client.Execute(request);

            var keyResponse = JsonConvert.DeserializeObject<Club.ClubResponse>(response.Content);

            this.ProcessResult(response, HttpStatusCode.OK);

            var item = new Club().CreateFromResponse(keyResponse);

            if (keyResponse.PublicContacts != null)
            {
                foreach (var id in keyResponse.PublicContacts)
                {
                    item.PublicContacts.Add(this.contactService.Get(id));
                }
            }

            return item;
        }
    }
}
