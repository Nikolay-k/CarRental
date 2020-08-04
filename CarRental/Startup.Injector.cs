using Microsoft.Extensions.DependencyInjection;

namespace CarRental
{
    using Context;
    using Implementation.DAL.Repositories;
    using Implementation.Storage;
    using Infrastructure.DAL.Context;
    using Infrastructure.DAL.Repositories;
    using Infrastructure.Storage;

    public partial class Startup
    {
        private void ConfigureInjector(IServiceCollection services)
        {
            #region Transient
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Singleton
            services.AddSingleton<IContextCreator, ContextCreator>();
            services.AddSingleton<IRepositoryCreator, RepositoryCreator>();
            #endregion
        }
    }
}
