namespace CarRental.Infrastructure.Storage
{
    using DAL.Repositories;
    using DAL.UnitOfWork;
    using Entities;

    // One thread. Transient initialization. Lazy members.
    public interface IUnitOfWork : IBaseUnitOfWork
    {
        IObjectRepository<User, int> UserRepository { get; }
        IObjectRepository<Car, int> CarRepository { get; }
        IObjectRepository<Order, int> OrderRepository { get; }
    }
}
