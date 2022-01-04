using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MOVEit.DTOs
{
    /// <summary>
    /// Folder Data Transfer Objects
    /// </summary>
    public class FolderItemDTO
    {
        [Required]
        [JsonPropertyName("FolderId")]
        public string ID { get; set; }

        [JsonPropertyName("hashtype")]
        public string Hashtype { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("comments")]
        public string Comments { get; set; }
    }
}

