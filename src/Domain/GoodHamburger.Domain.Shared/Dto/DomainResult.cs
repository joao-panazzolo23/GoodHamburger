namespace GoodHamburger.Domain.Shared.Dto;

public class DomainResult
{
    public DomainResult(params DomainError[] errors)
    {
        this.Errors.AddRange(errors);
    }
    public DomainResult Add(params DomainError[] errors)
    {
        this.Errors.AddRange(errors);
        return this;
    }

    public List<DomainError> Errors { get; set; } = [];
    public bool HasError => this.Errors.Any(x => !x.Error.Equals(string.Empty));
}
