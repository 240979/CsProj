namespace ElectronicStorage.Persistence.Models;

public abstract class EntityBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
}