namespace PokeApp2.Models
{
    public class Pokedex
    {
        [JsonConverter(typeof(DescriptionConverter))]
        public Descriptions Descriptions { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonConverter(typeof(TranslationConverter))]
        public Translations Names { get; set; }
        [JsonPropertyName("pokemon_entries")]
        public List<PokemonEntry> PokemonEntries { get; set; }
        [JsonIgnore]
        public int CountEntries { get; set; }
    }
}
