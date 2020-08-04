using System.Linq;

namespace CarRental.Infrastructure.DAL.Repositories
{
    public interface IBaseRepository<TBase>
        where TBase : class
    {
        IQueryable<TBase> Query { get; }

        string GetPresent(TBase entity);
    }
}
