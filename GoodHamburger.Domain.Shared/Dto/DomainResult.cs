namespace GoodHamburger.Domain.Shared.Dto;

public class DomainResult
{
    public DomainResult(params DomainError[] errors)
    {
        this.Errors.AddRange(errors);
    }
    public List<DomainError> Errors { get; set; } = [];
    public bool HasError => this.Errors.Any(x => !x.Error.Equals(string.Empty));
}

public record DomainError(string Error, string Description);



public static class CausesError
{
    public static DomainError DuplicateItem => new("Order.Duplicate", "Orders shouldn't have more than one of each product!");
    public static DomainError None => new(string.Empty, string.Empty);
}