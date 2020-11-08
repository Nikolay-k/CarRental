using Microsoft.EntityFrameworkCore;

namespace CarRental.Context.Builders
{
    internal static class MainModelBuilder
    {
        public static void BuildModel(ModelBuilder builder)
        {
            builder
                .HasAnnotation("ProductVersion", "3.1.9");
        }
    }
}
