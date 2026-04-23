namespace GoodHamburger.Domain.Shared.Entities;

public abstract class Entity
{
    public Guid Id { get; private init; } = Guid.CreateVersion7();
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

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