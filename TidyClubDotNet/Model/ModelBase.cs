namespace TidyClubDotNet.Model
{
    using Newtonsoft.Json;

    public class ModelBase : IConversion<ModelBase, ModelBase, ModelBase>
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "create_at")]
        public string CreateAt { get; set; }

        public ModelBase CreateFromResponse(ModelBase response)
        {
            return response;
        }

        public ModelBase CreateRequest()
        {
            return this;
        }
    }
}
