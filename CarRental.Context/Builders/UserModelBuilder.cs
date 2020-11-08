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
                    .ValueGeneratedOnAdd();
                b.Property(x => x.Surname)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);
                b.Property(x => x.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);
                b.Property(x => x.BirthDate);
                b.Property(x => x.DrivingLicenseNumber)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(20);

                b.HasKey(x => x.Id);

                b.ToTable("Users");
            });
        }
    }
}
