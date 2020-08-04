using System;

namespace CarRental.Infrastructure.DAL.FieldAssignment
{
    public interface IKey<T> where T : IEquatable<T>
    {
        T Id { get; set; }
    }
}
