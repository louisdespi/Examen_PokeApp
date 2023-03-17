namespace PokeApp2.Models
{
    public class PokemonSpecie
    {
        [JsonPropertyName("evolution_chain")]
        public ApiResource EvolutionChainResource { get; set; }
        [JsonIgnore]
        public EvolutionChain EvolutionChain { get; set; }
        [JsonConverter(typeof(TranslationConverter))]
        public Translations Names { get; set; }
        public List<PokemonVariety> Varieties { get; set; }
    }
}
