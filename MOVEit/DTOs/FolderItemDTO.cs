using System.Text.Json.Serialization;

namespace MOVEit.DTOs
{
    /// <summary>
    /// Folder Data Transfer Objects
    /// </summary>
    public class FolderItemDTO
    {
        [JsonPropertyName("hashtype")]
        public string hashtype { get; set; }

        [JsonPropertyName("hash")]
        public string hash { get; set; }

        [JsonPropertyName("comments")]
        public string comments { get; set; }
    }
}

