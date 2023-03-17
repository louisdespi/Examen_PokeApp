using System.Text.Json.Serialization;

namespace PokeApp2.Models
{
    public class Sprites
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }
    }
}
