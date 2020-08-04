using System.Collections.Generic;

namespace CarRental.Infrastructure.Entities
{
    using DAL.FieldAssignment;

    public class Car : IKey<int>
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Class { get; set; }
        public short IssueYear { get; set; }
        public string RegistrationNumber { get; set; }

        public List<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"{Brand} {Model} {RegistrationNumber}";
        }
    }
}
