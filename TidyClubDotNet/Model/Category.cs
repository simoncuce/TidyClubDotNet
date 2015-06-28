namespace TidyClubDotNet.Model
{
    using Newtonsoft.Json;

    public class Category : ModelBase
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "budget")]
        public decimal Budget { get; set; }

        [JsonProperty(PropertyName = "balance")]
        public decimal Balance { get; set; }
    }
}
