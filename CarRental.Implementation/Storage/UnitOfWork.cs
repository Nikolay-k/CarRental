namespace CarRental.Implementation.Storage
{
    using Implementation.DAL.UnitOfWork;
    using Infrastructure.DAL.Context;
    using Infrastructure.DAL.Repositories;
    using Infrastructure.Entities;
    using Infrastructure.Storage;

    public sealed class UnitOfWork : BaseUnitOfWork, IUnitOfWork
    {
        public UnitOfWork(
            IContextCreator contextCreator,
            IRepositoryCreator repositoryCreator)
            : base(
                contextCreator,
                repositoryCreator)
        {
        }

        public IObjectRepository<User, int> UserRepository => GetObjectRepository(ref _userRepository);
        private IObjectRepository<User, int> _userRepository;

        public IObjectRepository<Car, int> CarRepository => GetObjectRepository(ref _carRepository);
        private IObjectRepository<Car, int> _carRepository;

        public IObjectRepository<Order, int> OrderRepository => GetObjectRepository(ref _orderRepository);
        private IObjectRepository<Order, int> _orderRepository;
    }
}
