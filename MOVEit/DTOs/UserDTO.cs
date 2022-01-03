using System.Text.Json.Serialization;

namespace MOVEit.DTOs
{
    /// <summary>
    /// User Data Transfer Objects
    /// </summary>
    public class UserDTO
    {
        [JsonPropertyName("grant_type")]
        public string Grant_type { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
