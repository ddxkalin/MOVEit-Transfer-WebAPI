using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MOVEit.DTOs
{
    /// <summary>
    /// User Data Transfer Objects
    /// </summary>
    public class UserDTO
    {
        [Serializable]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum Grant_Types { password, refresh_token, otp, code, external_token }

        [Required]
        [JsonPropertyName("grant_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Grant_Types Grant_Type { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("orgId")]
        public string OrgId { get; set; }

        [JsonPropertyName("refresh_token")]
        public string Refresh_token { get; set; }

        [JsonPropertyName("mfa_access_token")]
        public string Mfa_refresh_token { get; set; }

        [JsonPropertyName("otp")]
        public string Otp { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("code_verifier")]
        public string Code_verifier { get; set; }

        [JsonPropertyName("accept_security_notice")]
        public bool Accept_security_notice { get; set; }

        [JsonPropertyName("mfa_remember_this_device")]
        public bool Mfa_remember_this_device { get; set; }

        [JsonPropertyName("mfa_trust_device_token")]
        public string Mfa_trust_device_token { get; set; }

        [JsonPropertyName("external_token_type")]
        public string External_token_type { get; set; }

    }
}
