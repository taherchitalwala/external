using System.Text.Json.Serialization;

namespace alvazaratAPI53.Models.ApiResponse
{
    public abstract class ApiResponseBase
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string ResponseType { get; set; } = string.Empty; // "object" or "array"
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Errors { get; set; }
    }
}
