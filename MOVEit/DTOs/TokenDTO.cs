using System.Text.Json.Serialization;

namespace MOVEit.DTOs
{
    /// <summary>
    /// Token Data Transfer Objects
    /// </summary>
    public class TokenDTO
    {
        [JsonPropertyName("access_token")]
        public string access_token { get; set; }

        [JsonPropertyName("token_type")]
        public string token_type { get; set; }

        [JsonPropertyName("expires_in")]
        public int expires_in { get; set; }

        [JsonPropertyName("refresh_token")]
        public string refresh_token { get; set; }
    }
}
