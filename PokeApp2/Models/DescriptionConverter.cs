using System.Text.Json;

namespace PokeApp2.Models
{
    public class DescriptionConverter : JsonConverter<Descriptions>
    {
        public override Descriptions Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var descriptions = new Descriptions { AllTranslations = new List<Description>() };

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    return descriptions;
                }

                if (reader.TokenType == JsonTokenType.StartObject)
                {
                    var description = JsonSerializer.Deserialize<Description>(ref reader, options);
                    descriptions.AllTranslations.Add(description);
                }
            }
            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Descriptions value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
