using System.ComponentModel;


namespace PokeApp2.Models
{
    public class Descriptions
    {
        public List<Description> AllTranslations { get; set; }
        [JsonIgnore]
        private string _t = null;
        [JsonIgnore]
        public string FrenchOrEnglish
        {
            get
            {
                if (_t == null)
                {
                    Description attempt = GetFrenchOrEnglish();
                    if (attempt is not null)
                    {
                        _t = attempt.Value;
                    }
                }
                return _t;
            }
            set
            {
                _t = value;
            }
        }

        public Description GetFrenchOrEnglish()
        {
            foreach (Description t in AllTranslations)
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
