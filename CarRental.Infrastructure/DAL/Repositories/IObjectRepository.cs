using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRental.Infrastructure.DAL.Repositories
{
    using FieldAssignment;

    public interface IObjectRepository<TObject, in TKey> : IBaseRepository<TObject>
        where TObject : class, IKey<TKey>
        where TKey : IEquatable<TKey>
    {
        TObject GetObject(TKey id, bool ignoreQueryFilters = false);
        Task<TObject> GetObjectAsync(TKey id, bool ignoreQueryFilters = false);
        List<TObject> GetObjects(Expression<Func<TObject, bool>> predicate, bool ignoreQueryFilters = false);
        Task<List<TObject>> GetObjectsAsync(Expression<Func<TObject, bool>> predicate, bool ignoreQueryFilters = false);
        void AddObject(TObject entity);
        void UpdateObject(TObject entity);
        void RemoveObject(TObject entity);
    }
}
