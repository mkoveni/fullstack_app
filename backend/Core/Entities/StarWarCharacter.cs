using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class StarWarCharacter
    {
        public string Name { set; get; }

        public string BirthYear { get; set; }

        public string EyeColor { get; set; }
    }
}