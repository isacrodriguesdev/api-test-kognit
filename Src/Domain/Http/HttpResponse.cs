using Microsoft.AspNetCore.Http.HttpResults;

namespace Domain.Http
{
    public class HttpResponse<T>
    {
        public int StatusCode { get; set; } = 200;
        public string? Message { get; set; }
        public T? Data { get; set; } = default;

        public HttpResponse<T> Result(T data, int statusCode = 200, string? message = null)
        {
            return new HttpResponse<T>
            {
                StatusCode = statusCode,
                Data = data,
                Message = message,
            };
        }

        public HttpResponse<T> Error(int statusCode, string message)
        {
            return new HttpResponse<T> { StatusCode = statusCode, Message = message };
        }

        public HttpResponse<T> InternalServerError()
        {
            return new HttpResponse<T> { StatusCode = 500, Message = "Internal server error" };
        }

        public HttpResponse<T> Ok(int statusCode = 200, string? message = null)
        {
            return new HttpResponse<T> { StatusCode = statusCode, Message = message };
        }
    }
}
