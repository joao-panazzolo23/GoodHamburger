using System.Net;
using System.Text.Json.Serialization;

namespace GoodHamburger.Application.Shared.Result;

public class Result<T>(
    HttpStatusCode statusCode,
    T? data,
    string? message = null
)
{
    [JsonIgnore] private readonly HttpStatusCode _statusCode = statusCode;
    [JsonIgnore] public int StatusCode => (int)_statusCode;
    public string? Message { get; private set; } = message;

    public T? Data { get; private set; } = data;
}