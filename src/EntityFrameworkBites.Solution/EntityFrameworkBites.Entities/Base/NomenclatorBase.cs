namespace EntityFrameworkBites.Entities.Base
{
    public abstract class NomenclatorBase: EntityBase<int>
    {
        public string Name { get; set; }
    }
}
