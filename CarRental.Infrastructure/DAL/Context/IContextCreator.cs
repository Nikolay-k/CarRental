using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.DAL.Context
{
    // Multiple threads. Singleton initialization.
    public interface IContextCreator
    {
        DbContext CreateContext();
    }
}
