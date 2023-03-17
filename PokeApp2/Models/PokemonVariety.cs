namespace PokeApp2.Models
{
    public class PokemonVariety
    {
        [JsonPropertyName("is_default")]
        public bool IsDefault { get; set; }
        [JsonPropertyName("pokemon")]
        public ApiResource PokemonResource { get; set; }
        [JsonIgnore]
        public Pokemon Pokemon { get; set; }
    }
}
