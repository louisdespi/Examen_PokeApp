namespace PokeApp2.Models
{
    public class VersionGroup
    {
        public int Id { get; set; }

        [JsonPropertyName("pokedexes")]
        public List<ApiResource> PokedexesResource { get; set; }

        [JsonIgnore]
        public List<Pokedex> Pokedexes { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("versions")]
        public List<ApiResource> VersionsResource { get; set; }

        [JsonIgnore]
        public VersionGroup Versions { get; set; }

        [JsonPropertyName("generation")]
        public ApiResource GenerationResource { get; set; }

        [JsonIgnore]
        public Generation Generation { get; set; }  
    }
}
