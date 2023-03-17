using System.ComponentModel;


namespace PokeApp2.Models
{
    public class Translations
    {
        public List<Translation> AllTranslations { get; set; }
        [JsonIgnore]
        private string _t = null;
        [JsonIgnore]
        public string FrenchOrEnglish
        {
            get
            {
                if (_t == null)
                {
                    Translation attempt = GetFrenchOrEnglish();
                    if (attempt is not null)
                    {
                        _t = attempt.Name;
                    }
                }
                return _t;
            }
            set
            {
                _t = value;
            }
        }

        public Translation GetFrenchOrEnglish()
        {
            foreach (Translation t in AllTranslations)
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
