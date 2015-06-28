namespace TidyClubDotNet.Misc
{
    using System.IO;

    using Newtonsoft.Json;

    using RestSharp.Serializers;

    public class RestSharpJsonNetSerializer : ISerializer
    {
        private readonly Newtonsoft.Json.JsonSerializer serializer;

        public RestSharpJsonNetSerializer()
        {
            this.ContentType = "application/json";
            this.serializer = new Newtonsoft.Json.JsonSerializer
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Include,
                DefaultValueHandling = DefaultValueHandling.Include
            };
        }

        public RestSharpJsonNetSerializer(Newtonsoft.Json.JsonSerializer serializer)
        {
            this.ContentType = "application/json";
            this.serializer = serializer;
        }

        public string ContentType { get; set; }

        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }
        
        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonTextWriter.QuoteChar = '"';

                    this.serializer.Serialize(jsonTextWriter, obj);

                    var result = stringWriter.ToString();
                    return result;
                }
            }
        }
    }
}
