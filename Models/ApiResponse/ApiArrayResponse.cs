namespace alvazaratAPI53.Models.ApiResponse
{
    public class ApiArrayResponse<T> : ApiResponseBase
    {
        public IEnumerable<T>? Data { get; set; }
        public int? TotalCount { get; set; }

        public static ApiArrayResponse<T> Ok(IEnumerable<T> data, string? message = null)
            => new()
            {
                Success = true,
                Message = message ?? "Success",
                Data = data,
                TotalCount = data?.Count(),
                ResponseType = "array"
            };

        public static ApiArrayResponse<T> Fail(string message, List<string>? errors = null)
            => new()
            {
                Success = false,
                Message = message,
                Errors = errors,
                ResponseType = "array"
            };
    }
}
