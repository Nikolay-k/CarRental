using Microsoft.EntityFrameworkCore;
using System;

namespace CarRental.Infrastructure.DAL.Repositories
{
    using FieldAssignment;

    // Multiple threads. Singleton initialization.
    public interface IRepositoryCreator
    {
        IObjectRepository<TObject, TKey> CreateObjectRepository<TObject, TKey>(DbContext context)
            where TObject : class, IKey<TKey>
            where TKey : IEquatable<TKey>;
    }
}
