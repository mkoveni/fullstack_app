using System.Collections.Generic;
using System.Text.Json.Serialization;
using Core.Entities;

namespace Infrastructure.Models
{
    public class SwapiCollectionResponse
    {
        [JsonPropertyName("results")]
        public List<SwapiCharacter> Results { get; set; }
    }
}