using System.Text.Json.Serialization;

namespace MOVEit.DTOs
{
    public class FileItemDTO
    {
        [JsonPropertyName("fileId")]
        public string fileId { get; set; }

        [JsonPropertyName("bytes")]
        public int bytes { get; set; }

        [JsonPropertyName("maxChunkSize")]
        public int maxChunkSize { get; set; }

        [JsonPropertyName("orgID")]
        public string orgID { get; set; }

        [JsonPropertyName("folderID")]
        public string folderID { get; set; }

        [JsonPropertyName("originalFileType")]
        public string originalFileType { get; set; }

        [JsonPropertyName("currentFileType")]
        public string currentFileType { get; set; }

        [JsonPropertyName("uploadComment")]
        public string uploadComment { get; set; }

        [JsonPropertyName("uploadUsername")]
        public string uploadUsername { get; set; }

        [JsonPropertyName("uploadAgentVersion")]
        public string uploadAgentVersion { get; set; }

        [JsonPropertyName("uploadStamp")]
        public string uploadStamp { get; set; }

        [JsonPropertyName("uploadIntegrity")]
        public int uploadIntegrity { get; set; }

        [JsonPropertyName("hash")]
        public string hash { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("size")]
        public int size { get; set; }

        [JsonPropertyName("isNew")]
        public bool isNew { get; set; }

        [JsonPropertyName("path")]
        public string path { get; set; }

        [JsonPropertyName("downloadCount")]
        public int downloadCount { get; set; }

        [JsonPropertyName("originalFilename")]
        public string originalFilename { get; set; }

        [JsonPropertyName("dlpViolation")]
        public string dlpViolation { get; set; }

        [JsonPropertyName("dlpMetaData")]
        public int dlpMetaData { get; set; }

        [JsonPropertyName("dlpChecked")]
        public bool dlpChecked { get; set; }

        [JsonPropertyName("dlpBlocked")]
        public bool dlpBlocked { get; set; }
    }
}
