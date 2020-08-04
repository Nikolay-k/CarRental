using Microsoft.EntityFrameworkCore;

namespace CarRental.Context.Builders
{
    using Infrastructure.Entities;

    internal static class CarModelBuilder
    {
        public static void BuildModel(ModelBuilder builder)
        {
            builder.Entity<Car>(b =>
            {
                b.Property(x => x.Id)
                    .ValueGeneratedOnAdd();
                b.Property(x => x.Brand)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(20);
                b.Property(x => x.Model)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(20);
                b.Property(x => x.Class)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(10);
                b.Property(x => x.IssueYear);
                b.Property(x => x.RegistrationNumber)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(10);

                b.HasKey(x => x.Id);

                b.ToTable("Cars");
            });
        }
    }
}
