using Microsoft.EntityFrameworkCore;
using System;

namespace CarRental.Infrastructure.DAL.UnitOfWork
{
    // One thread. Transient initialization. Lazy members.
    public interface IBaseUnitOfWork : IDisposable
    {
        DbContext Context { get; }
    }
}
