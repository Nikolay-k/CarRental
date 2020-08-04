using Microsoft.EntityFrameworkCore;
using System;

namespace CarRental.Implementation.DAL.Repositories
{
    using Infrastructure.DAL.FieldAssignment;
    using Infrastructure.DAL.Repositories;

    public class RepositoryCreator : IRepositoryCreator
    {
        public IObjectRepository<TObject, TKey> CreateObjectRepository<TObject, TKey>(DbContext context)
            where TObject : class, IKey<TKey>
            where TKey : IEquatable<TKey>
        {
            return new ObjectRepository<TObject, TKey>(context);
        }
    }
}
