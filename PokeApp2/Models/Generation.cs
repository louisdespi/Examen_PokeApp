using System;

namespace PokeApp2.Models
{
    public class Generation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonConverter(typeof(TranslationConverter))]
        public Translations Names { get; set; }

        [JsonPropertyName("version_groups")]
        public List<ApiResource> VersionGroupsResource { get; set; }

        [JsonIgnore]
        public List<VersionGroup> VersionGroups { get; set; }
    }
}
