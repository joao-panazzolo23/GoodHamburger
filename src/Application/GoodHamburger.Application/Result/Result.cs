using GoodHamburger.Domain.Shared.Dto;
using System.Net;
using System.Text.Json.Serialization;

namespace GoodHamburger.Application.Result;

public class Result<T>(
    HttpStatusCode statusCode,
    T? data,
    string? message = null,
    IEnumerable<DomainError>? errors = null

)
{
    [JsonIgnore] private readonly HttpStatusCode _statusCode = statusCode;
    [JsonIgnore] public int StatusCode => (int)_statusCode;
    public string? Message { get; private set; } = message;
    public IEnumerable<DomainError>? Errors { get; set; } = errors;
    public T? Data { get; private set; } = data;
}