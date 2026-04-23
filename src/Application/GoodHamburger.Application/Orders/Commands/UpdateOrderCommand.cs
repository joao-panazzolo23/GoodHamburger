namespace GoodHamburger.Application.Orders.Commands;


public record UpdateOrderCommand(
    Guid Id,
    string Name,
    string PhoneNumber,
    string Email,
    IList<CreateOrderItemCommand> Items
    ) : CreateOrderCommand(Name, PhoneNumber, Email, Items);
