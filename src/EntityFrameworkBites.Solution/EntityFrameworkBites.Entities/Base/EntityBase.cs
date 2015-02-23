namespace EntityFrameworkBites.Entities.Base
{
    public abstract class EntityBase<T>
    {
       public T Id { get; set; }
    }
}
