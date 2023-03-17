using System.Text.Json;

namespace PokeApp2.Models
{
    public class TranslationConverter : JsonConverter<Translations>
    {
        public override Translations Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var translations = new Translations { AllTranslations = new List<Translation>() };

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    return translations;
                }

                if (reader.TokenType == JsonTokenType.StartObject)
                {
                    var translation = JsonSerializer.Deserialize<Translation>(ref reader, options);
                    translations.AllTranslations.Add(translation);
                }
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Translations value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
