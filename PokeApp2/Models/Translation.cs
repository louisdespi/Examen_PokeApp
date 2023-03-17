namespace PokeApp2.Models
{
    public class Translation
    {
        public string Name { get; set; }
        [JsonPropertyName("language")]
        public ApiResource LanguageResource { get; set; }
        [JsonIgnore]
        public Language Language { get; set; }
    }
}
