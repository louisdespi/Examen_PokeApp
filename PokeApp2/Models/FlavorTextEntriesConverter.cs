using System.Text.Json;

namespace PokeApp2.Models
{
    public class FlavorTextEntriesConverter : JsonConverter<FlavorTextEntries>
    {
        public override FlavorTextEntries Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var translations = new FlavorTextEntries { AllTranslations = new List<FlavorTextEntry>() };

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    return translations;
                }

                if (reader.TokenType == JsonTokenType.StartObject)
                {
                    var translation = JsonSerializer.Deserialize<FlavorTextEntry>(ref reader, options);
                    translations.AllTranslations.Add(translation);
                }
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, FlavorTextEntries value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
