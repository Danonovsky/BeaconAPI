namespace BeaconAPI.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime LastModificationDate { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;
}
