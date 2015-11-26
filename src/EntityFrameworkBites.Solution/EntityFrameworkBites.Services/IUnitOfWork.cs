using EntityFrameworkBites.DataModel.Base;

namespace EntityFrameworkBites.Services
{
    public interface IUnitOfWork
    {
        IDbEntities Context { get; }
        void Commit();
    }
}
