using System;
using System.Collections.Generic;

namespace CarRental.Infrastructure.Entities
{
    using DAL.FieldAssignment;

    public class User : IKey<int>
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string DrivingLicenseNumber { get; set; }

        public List<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"{Surname} {Name}";
        }
    }
}
