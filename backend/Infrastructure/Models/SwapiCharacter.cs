using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public class SwapiCharacter
    {
        public string Name { set; get; }

        [JsonPropertyName("birth_year")]
        public string BirthYear { get; set; }

        [JsonPropertyName("eye_color")]
        public string EyeColor { get; set; }
    }
}