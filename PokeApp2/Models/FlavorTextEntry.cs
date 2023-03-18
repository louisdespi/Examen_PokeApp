namespace PokeApp2.Models
{
    public class FlavorTextEntry
    {
        [JsonPropertyName("flavor_text")]
        public string FlavorText { get; set; }
        [JsonPropertyName("language")]
        public ApiResource LanguageResource { get; set; }
        [JsonIgnore]
        public Language Language { get; set; }
        [JsonPropertyName("version")]
        public ApiResource VersionResource { get; set; }
        [JsonIgnore]
        public Version Version { get; set; }
    }
}
