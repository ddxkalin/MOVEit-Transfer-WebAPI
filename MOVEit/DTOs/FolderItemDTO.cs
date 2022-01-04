using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace MOVEit.DTOs
{
    /// <summary>
    /// Folder Data Transfer Objects
    /// </summary>
    public class FolderItemDTO
    {
        [JsonPropertyName("FolderId")]
        public string FolderID { get; set; }

        [JsonPropertyName("hashtype")]
        public string Hashtype { get; set; }

        [JsonPropertyName("file")]
        public IFormFile File { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("comments")]
        public string Comments { get; set; }
    }
}

