
namespace PokeApp2.Models
{
    public class Version
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Translation[] Names { get; set; }
        [JsonPropertyName("version_group")]
        public ApiResource VersionGroupResource { get; set; }
        [JsonIgnore]
        public VersionGroup VersionGroup { get; set; }
    }
}
