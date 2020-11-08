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
                    .HasColumnType("INTEGER")
                    .ValueGeneratedOnAdd();
                b.Property(x => x.Brand)
                    .HasColumnType("TEXT")
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(20);
                b.Property(x => x.Model)
                    .HasColumnType("TEXT")
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(20);
                b.Property(x => x.Class)
                    .HasColumnType("TEXT")
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(10);
                b.Property(x => x.IssueYear)
                    .HasColumnType("INTEGER");
                b.Property(x => x.RegistrationNumber)
                    .HasColumnType("TEXT")
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(10);

                b.HasKey(x => x.Id);

                b.ToTable("Cars");
            });
        }
    }
}
