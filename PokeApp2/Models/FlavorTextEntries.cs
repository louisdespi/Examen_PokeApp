using System.ComponentModel;


namespace PokeApp2.Models
{
    public class FlavorTextEntries
    {
        public List<FlavorTextEntry> AllTranslations { get; set; }
        [JsonIgnore]
        private string _t = null;
        [JsonIgnore]
        public string FrenchOrEnglish
        {
            get
            {
                if (_t == null)
                {
                    FlavorTextEntry attempt = GetFrenchOrEnglish();
                    if (attempt is not null)
                    {
                        _t = attempt.FlavorText;
                    }
                }
                return _t;
            }
            set
            {
                _t = value;
            }
        }

        public FlavorTextEntry GetFrenchOrEnglish()
        {
            foreach (FlavorTextEntry t in AllTranslations)
            {
                if (t.LanguageResource.Name == "fr")
                {
                    return t;
                }
                if (t.LanguageResource.Name == "en")
                {
                    return t;
                }
            }
            return null;
        }
    }
}
