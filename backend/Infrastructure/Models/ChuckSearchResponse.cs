using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace Infrastructure.Models
{
    public class ChuckSearchResponse
    {

        [JsonPropertyName("result")]
        public List<ChuckJoke> Results { get; set; }
    }
}