using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRental.Implementation.DAL.Repositories
{
    using Infrastructure.DAL.FieldAssignment;
    using Infrastructure.DAL.Repositories;

    public class ObjectRepository<TObject, TKey> : BaseRepository<TObject>,
        IObjectRepository<TObject, TKey>
        where TObject : class, IKey<TKey>
        where TKey : IEquatable<TKey>
    {
        public ObjectRepository(DbContext context) : base(context) { }

        protected DbSet<TObject> Set => _set ?? (_set = Context.Set<TObject>());
        private DbSet<TObject> _set;

        public TObject GetObject(TKey id, bool ignoreQueryFilters = false)
        {
            return ignoreQueryFilters ?
                Set.IgnoreQueryFilters().SingleOrDefault(x => x.Id.Equals(id)) :
                Set.SingleOrDefault(x => x.Id.Equals(id));
        }

        public async Task<TObject> GetObjectAsync(TKey id, bool ignoreQueryFilters = false)
        {
            return ignoreQueryFilters ?
                await Set.IgnoreQueryFilters().SingleOrDefaultAsync(x => x.Id.Equals(id)) :
                await Set.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public List<TObject> GetObjects(Expression<Func<TObject, bool>> predicate, bool ignoreQueryFilters = false)
        {
            return ignoreQueryFilters ?
                Set.IgnoreQueryFilters().Where(predicate).ToList() :
                Set.Where(predicate).ToList();
        }

        public async Task<List<TObject>> GetObjectsAsync(Expression<Func<TObject, bool>> predicate, bool ignoreQueryFilters = false)
        {
            return ignoreQueryFilters ?
                await Set.IgnoreQueryFilters().Where(predicate).ToListAsync() :
                await Set.Where(predicate).ToListAsync();
        }

        public void AddObject(TObject entity)
        {
            Context.Add(entity);
        }

        public void UpdateObject(TObject entity)
        {
            Context.Update(entity);
        }

        public void RemoveObject(TObject entity)
        {
            Context.Remove(entity);
        }
    }
}
