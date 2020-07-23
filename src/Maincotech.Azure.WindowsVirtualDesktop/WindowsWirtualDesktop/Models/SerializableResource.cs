using Azure.Core;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.WindowsWirtualDesktop.Models
{
    public abstract class SerializableResource<T> : IUtf8JsonSerializable
    {
        public static T Deserialize(string json, JsonSerializerOptions options = default)
        {
            var myOptions = options ?? new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
            };
            return JsonSerializer.Deserialize<T>(json, options);
        }

        public static async Task<T> DeserializeAsync(Stream stream, JsonSerializerOptions options = default, CancellationToken cancellationToken = default)
        {
            var myOptions = options ?? new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
            };
            return await JsonSerializer.DeserializeAsync<T>(stream, myOptions, cancellationToken);
        }

        public virtual void Write(Utf8JsonWriter writer)
        {
            var jsonString = Serialize();
            using JsonDocument document = JsonDocument.Parse(jsonString);
            JsonElement root = document.RootElement;

            if (root.ValueKind == JsonValueKind.Object)
            {
                writer.WriteStartObject();
            }
            else
            {
                return;
            }

            foreach (JsonProperty property in root.EnumerateObject())
            {
                property.WriteTo(writer);
            }

            writer.WriteEndObject();

            writer.Flush();
        }

        public string Serialize(T valude)
        {
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
            };
            return JsonSerializer.Serialize<T>(valude, options);
        }

        protected abstract string Serialize();
    }
}