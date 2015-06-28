namespace TidyClubDotNet.Model
{
    using Newtonsoft.Json;

    public class Choice : ModelBase
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}
