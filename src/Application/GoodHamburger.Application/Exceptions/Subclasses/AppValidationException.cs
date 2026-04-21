using FluentValidation.Results;
using GoodHamburger.Application.Shared.Exceptions.Dtos;

namespace GoodHamburger.Presentation.Api.Exceptions.Subclasses;

public sealed class AppValidationException : Exception
{
    public AppValidationException(IEnumerable<ValidationFailure> failures)
    {
        Errors = failures.Select(x => new ExceptionDetail(x.PropertyName, x.ErrorMessage));
    }

    public AppValidationException(IEnumerable<ExceptionDetail> details)
    {
        Errors = details;
    }

    public IEnumerable<ExceptionDetail> Errors { get; private init; }
}