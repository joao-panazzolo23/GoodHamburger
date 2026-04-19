namespace GoodHamburger.Domain.Shared.Exceptions;

public class DomainException(string error) : Exception(error);
