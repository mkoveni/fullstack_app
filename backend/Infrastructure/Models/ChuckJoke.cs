using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class ChuckJoke
    {

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("icon_url")]
        public string IconUrl { get; set; }

        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; }
    }
}