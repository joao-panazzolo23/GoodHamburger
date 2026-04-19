namespace GoodHamburger.Domain.Shared.Entities;

public abstract class Entity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    //todo: notification pattern
    // public Notification Notification { get; private set; } = new();

    public void SetCreatedAt()
    {
        CreatedAt = DateTime.UtcNow;
    }

    public void SetUpdatedAt()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}