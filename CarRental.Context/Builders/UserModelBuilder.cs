using Microsoft.EntityFrameworkCore;

namespace CarRental.Context.Builders
{
    using Infrastructure.Entities;

    internal static class UserModelBuilder
    {
        public static void BuildModel(ModelBuilder builder)
        {
            builder.Entity<User>(b =>
            {
                b.Property(x => x.Id)
                    .HasColumnType("INTEGER")
                    .ValueGeneratedOnAdd();
                b.Property(x => x.Surname)
                    .HasColumnType("TEXT")
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);
                b.Property(x => x.Name)
                    .HasColumnType("TEXT")
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);
                b.Property(x => x.BirthDate)
                    .HasColumnType("TEXT");
                b.Property(x => x.DrivingLicenseNumber)
                    .HasColumnType("TEXT")
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(20);

                b.HasKey(x => x.Id);

                b.ToTable("Users");
            });
        }
    }
}
