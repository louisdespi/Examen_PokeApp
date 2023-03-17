namespace PokeApp2.Models
{
    public class Chain
    {
        [JsonPropertyName("evolves_to")]
        public PokeApp2.Models.Chain[] EvolvesTo { get; set; }
        [JsonPropertyName("is_baby")]
        public bool IsBaby { get; set; }
        [JsonPropertyName("species")]
        public ApiResource PokemonSpecieResource { get; set; }
        [JsonIgnore]
        public PokemonSpecie PokemonSpecie { get; set; }
    }
}
