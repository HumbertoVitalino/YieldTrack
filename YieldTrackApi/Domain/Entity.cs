namespace Domain;

public abstract class Entity(Guid? id)
{
    public Guid Id { get; private set; } = id ?? Guid.NewGuid();
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public DateTime UpdatedAt { get; private set; } = DateTime.Now;

    protected void SetUpdatedAt() => UpdatedAt = DateTime.Now;
}
