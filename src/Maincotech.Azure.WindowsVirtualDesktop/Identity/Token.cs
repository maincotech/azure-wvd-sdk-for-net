using Azure.Serialization;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Azure.Identity
{
    public class Token
    {
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("expires_in")]
        public string ExpiresIn { get; set; }

        [JsonPropertyName("ext_expires_in")]
        public string ExtExpiresIn { get; set; }

        [JsonPropertyName("expires_on")]
        [JsonConverter(typeof(LongConverter))]
        public long ExpiresOn { get; set; }

        [JsonPropertyName("not_before")]
        [JsonConverter(typeof(LongConverter))]
        public long NotBefore { get; set; }

        [JsonPropertyName("resource")]
        public string Resource { get; set; }

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("id_token")]
        public string IdToken { get; set; }

        [JsonPropertyName("client_info")]
        public string ClientInfo { get; set; }

        public static Token Deserialize(string json)
        {
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
            };
            return JsonSerializer.Deserialize<Token>(json, options);
        }

        public static async Task<Token> DeserializeAsync(Stream stream)
        {
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
            };
            return await JsonSerializer.DeserializeAsync<Token>(stream, options);
        }

        public string Serialize()
        {
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
            };
            return JsonSerializer.Serialize<Token>(this, options);
        }
    }
}