using Microsoft.EntityFrameworkCore;

namespace CarRental.Context.Builders
{
    using Infrastructure.Entities;

    internal static class OrderModelBuilder
    {
        public static void BuildModel(ModelBuilder builder)
        {
            builder.Entity<Order>(b =>
            {
                b.Property(x => x.Id)
                    .HasColumnType("INTEGER")
                    .ValueGeneratedOnAdd();
                b.Property(x => x.UserId)
                    .HasColumnType("INTEGER");
                b.Property(x => x.CarId)
                    .HasColumnType("INTEGER");
                b.Property(x => x.RentalStartDate)
                    .HasColumnType("TEXT");
                b.Property(x => x.RentalEndDate)
                    .HasColumnType("TEXT");
                b.Property(x => x.Comment)
                    .HasColumnType("TEXT")
                    .IsUnicode()
                    .HasMaxLength(200);

                b.HasKey(x => x.Id);

                b.HasIndex(x => x.UserId);

                b.HasOne(x => x.User)
                    .WithMany(x => x.Orders)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasIndex(x => x.CarId);

                b.HasOne(x => x.Car)
                    .WithMany(x => x.Orders)
                    .HasForeignKey(x => x.CarId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.ToTable("Orders");
            });
        }
    }
}
