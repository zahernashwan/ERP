namespace ERP.Domain;

public abstract class Entity<TId>
{
    protected Entity(TId id)
    {
        ArgumentNullException.ThrowIfNull(id);
        Id = id;
    }

    public TId Id { get; }
}
