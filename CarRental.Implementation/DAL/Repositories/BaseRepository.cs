using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CarRental.Implementation.DAL.Repositories
{
    using Infrastructure.DAL.Repositories;

    public abstract class BaseRepository<TBase> : IBaseRepository<TBase>
        where TBase : class
    {
        protected readonly DbContext Context;

        protected BaseRepository(DbContext context)
        {
            Context = context;
        }

        public virtual IQueryable<TBase> Query => _query ?? (_query = Context.Set<TBase>().AsNoTracking());
        private IQueryable<TBase> _query;

        public virtual string GetPresent(TBase entity)
        {
            return entity.ToString();
        }
    }
}
