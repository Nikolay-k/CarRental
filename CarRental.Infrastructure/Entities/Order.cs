using System;

namespace CarRental.Infrastructure.Entities
{
    using DAL.FieldAssignment;

    public class Order : IKey<int>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public string Comment { get; set; }

        public User User { get; set; }
        public Car Car { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
