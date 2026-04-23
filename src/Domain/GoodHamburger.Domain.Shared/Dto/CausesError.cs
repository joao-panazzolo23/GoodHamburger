namespace GoodHamburger.Domain.Shared.Dto;

public static class CausesError
{
    public static DomainError DuplicateItem => new("Order.Duplicate", "Orders shouldn't have more than one of each product category!");
    public static DomainError None => new(string.Empty, string.Empty);
}