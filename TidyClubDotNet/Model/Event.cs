namespace TidyClubDotNet.Model
{
    using System;

    using Newtonsoft.Json;

    public class Event : ModelBase
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "start_at")]
        public DateTime StartDate { get; set; }

        [JsonProperty(PropertyName = "end_at")]
        public DateTime EndDate { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        [JsonProperty(PropertyName = "archived")]
        public bool Archived { get; set; }

        [JsonProperty(PropertyName = "public")]
        public bool Public { get; set; }

        [JsonProperty(PropertyName = "hidden")]
        public bool Hidden { get; set; }

        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }
    }
}
