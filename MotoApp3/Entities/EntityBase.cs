namespace MotoApp3.Entities;

public abstract class EntityBase : IEntity
{
    public int ? Id { get; set; }

    public virtual string String2()
    {
        throw new NotImplementedException();
    }
}
