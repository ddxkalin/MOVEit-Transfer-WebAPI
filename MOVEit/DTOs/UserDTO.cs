using System.Text.Json.Serialization;

namespace MOVEit.DTOs
{
    public class UserDTO
    {
        [JsonPropertyName("grant_type")]
        public string Grant_type = "password";

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
