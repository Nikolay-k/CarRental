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
            _dbContextOptions = builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).Options;
        }

        public DbContext CreateContext()
        {
            return new AppDbContext(_dbContextOptions);
        }
    }
}
