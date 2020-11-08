using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarRental.Context
{
    using Infrastructure.DAL.Context;

    public class ContextCreator : IContextCreator
    {
        private readonly DbContextOptions _dbContextOptions;

        public ContextCreator(IConfiguration configuration)
        {
            var builder = new DbContextOptionsBuilder();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _dbContextOptions = !string.IsNullOrEmpty(connectionString) ?
                builder.UseSqlServer(connectionString).Options :
                builder.UseInMemoryDatabase("carrental").Options;
        }

        public DbContext CreateContext()
        {
            return new AppDbContext(_dbContextOptions);
        }
    }
}
