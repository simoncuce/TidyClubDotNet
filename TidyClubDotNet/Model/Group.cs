namespace TidyClubDotNet.Model
{
    using Newtonsoft.Json;

    public class Group : ModelBase
    {
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
