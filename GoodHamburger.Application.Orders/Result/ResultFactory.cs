using GoodHamburger.Domain.Shared.Dto;
using System.Net;

namespace GoodHamburger.Application.Result;

public static class ResultFactory<T>
{
    //todo: implement error returns, consider OneOf or CSharpFunctionalExtensions
    public static Result<T?> Ok(T? data = default, string? message = null) =>
        new(statusCode: HttpStatusCode.OK, data, message);

    public static Result<T?> Unauthorized(T? data = default, string? message = null) =>
        new(statusCode: HttpStatusCode.Unauthorized, data, message);

    public static Result<T?> BadRequest(string? message = null, IEnumerable<DomainError>? errors = null) =>
        new(
            statusCode: HttpStatusCode.BadRequest,
            data: default,
            message: message,
            errors: errors
        );

    public static Result<T?> NotFound(string? message = null) =>
        new(HttpStatusCode.NotFound, default, message);

    public static Result<T?> Conflict(string? message = null) =>
        new(HttpStatusCode.Conflict, default, message);

}