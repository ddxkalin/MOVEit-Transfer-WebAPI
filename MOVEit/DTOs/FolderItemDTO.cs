using System.Text.Json.Serialization;

namespace MOVEit.DTOs
{
    public class FolderItemDTO
    {
        [JsonPropertyName("FolderId")]
        public string FolderID { get; set; }

        [JsonPropertyName("file")]
        public string File { get; set; }

        [JsonPropertyName("hashtype")]
        public string Hashtype { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("comments")]
        public string Comments { get; set; }
    }
}

