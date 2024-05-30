using CoreTest.Models.Interfaces;
using CoreTest.Models.Pakistan;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CoreTest.JsonConverters.Pakistan
{
    public class ClientConverter : JsonConverter<IClient>
    {
        public override IClient? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<Client>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, IClient value, JsonSerializerOptions options)
        {
            string json = JsonSerializer.Serialize(value as Client, options);
            writer.WriteRawValue(json);
        }
    }
}
