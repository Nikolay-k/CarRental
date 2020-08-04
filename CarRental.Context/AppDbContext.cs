using Microsoft.EntityFrameworkCore;

namespace CarRental.Context
{
    using Builders;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            UserModelBuilder.BuildModel(builder);
            CarModelBuilder.BuildModel(builder);
            OrderModelBuilder.BuildModel(builder);
        }
    }
}
