using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CarRental.Context
{
    using Infrastructure.DAL.Context;

    public class ContextCreator : IContextCreator
    {
        private readonly DbContextOptions _dbContextOptions;

        public ContextCreator(IConfiguration configuration)
        {
            var dbPath = "";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                dbPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "db");
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                dbPath = "/home/logfiles";

            if (!Directory.Exists(dbPath))
                Directory.CreateDirectory(dbPath);

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var sqliteConnectionStringBuilder = new SqliteConnectionStringBuilder(connectionString);
            sqliteConnectionStringBuilder.DataSource = Path.Combine(dbPath, sqliteConnectionStringBuilder.DataSource);
            connectionString = sqliteConnectionStringBuilder.ToString();

            var builder = new DbContextOptionsBuilder();
            _dbContextOptions = builder.UseSqlite(connectionString).Options;
        }

        public DbContext CreateContext()
        {
            return new AppDbContext(_dbContextOptions);
        }
    }
}
