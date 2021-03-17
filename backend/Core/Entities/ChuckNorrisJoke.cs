using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class ChuckNorrisJoke
    {
        public string Value { get; set; }

        public string IconUrl { get; set; }

        public List<string> Categories { get; set; }
    }
}