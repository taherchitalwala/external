namespace alvazaratAPI53.Models.ApiResponse
{
    public class ApiObjectResponse<T> : ApiResponseBase
    {
        public T? Data { get; set; }

        public static ApiObjectResponse<T> Ok(T data, string? message = null)
            => new()
            {
                Success = true,
                Message = message ?? "Success",
                Data = data,
                ResponseType = "object"
            };

        public static ApiObjectResponse<T> Fail(string message, List<string>? errors = null)
            => new()
            {
                Success = false,
                Message = message,
                Errors = errors,
                ResponseType = "object"
            };
    }
}
