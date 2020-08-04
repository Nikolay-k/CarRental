using Microsoft.EntityFrameworkCore;
using System;

namespace CarRental.Implementation.DAL.UnitOfWork
{
    using Infrastructure.DAL.Context;
    using Infrastructure.DAL.FieldAssignment;
    using Infrastructure.DAL.Repositories;
    using Infrastructure.DAL.UnitOfWork;

    public abstract class BaseUnitOfWork : IBaseUnitOfWork
    {
        private readonly IContextCreator _contextCreator;
        private readonly IRepositoryCreator _repositoryCreator;

        protected BaseUnitOfWork(
            IContextCreator contextCreator,
            IRepositoryCreator repositoryCreator)
        {
            _contextCreator = contextCreator;
            _repositoryCreator = repositoryCreator;
        }

        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }

            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~BaseUnitOfWork()
        {
            Dispose(false);
        }

        protected IObjectRepository<TObject, TKey> GetObjectRepository<TObject, TKey>(ref IObjectRepository<TObject, TKey> repository)
            where TObject : class, IKey<TKey>
            where TKey : IEquatable<TKey>
        {
            if (repository != null)
                return repository;

            return repository = _repositoryCreator.CreateObjectRepository<TObject, TKey>(Context);
        }

        public DbContext Context => _context ?? (_context = _contextCreator.CreateContext());
        private DbContext _context;
    }
}
