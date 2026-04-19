using GoodHamburger.Domain.Shared.Entities;

namespace GoodHamburger.Domain.Order.Entities;

public class Order : Entity
{
    public string Name { get; private set; }
    public decimal Value { get; private set; }

    //ef-core
    private Order()
    {
    }
    
    public Order Create(string name, decimal value)
    {
        Name = name;
        Value =  value;
        return this;
    }
}