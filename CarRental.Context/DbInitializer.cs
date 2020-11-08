using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace CarRental.Context
{
    using Infrastructure.Entities;
    using Infrastructure.Storage;

    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            try
            {
                using var unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();

                // users
                if (!unitOfWork.UserRepository.Query.Any())
                {
                    var user = new User
                    {
                        Surname = "Petrov",
                        Name = "Ivan",
                        BirthDate = DateTime.Parse("1975-08-22"),
                        DrivingLicenseNumber = "AA365789"
                    };
                    unitOfWork.UserRepository.AddObject(user);
                    user = new User
                    {
                        Surname = "Sidorov",
                        Name = "Alex",
                        BirthDate = DateTime.Parse("1980-10-24"),
                        DrivingLicenseNumber = "AB663424"
                    };
                    unitOfWork.UserRepository.AddObject(user);
                    user = new User
                    {
                        Surname = "Vetrov",
                        Name = "Vasiliy",
                        BirthDate = DateTime.Parse("2001-09-01"),
                        DrivingLicenseNumber = "AF555232"
                    };
                    unitOfWork.UserRepository.AddObject(user);
                }

                // cars
                if (!unitOfWork.CarRepository.Query.Any())
                {
                    var car = new Car
                    {
                        Brand = "Ford",
                        Model = "Focus",
                        Class = "Econom",
                        IssueYear = 2015,
                        RegistrationNumber = "A2046ST"
                    };
                    unitOfWork.CarRepository.AddObject(car);
                    car = new Car
                    {
                        Brand = "Opel",
                        Model = "Corsa",
                        Class = "Econom",
                        IssueYear = 2010,
                        RegistrationNumber = "B6654GT"
                    };
                    unitOfWork.CarRepository.AddObject(car);
                    car = new Car
                    {
                        Brand = "BMW",
                        Model = "X5",
                        Class = "Business",
                        IssueYear = 2019,
                        RegistrationNumber = "D3553DD"
                    };
                    unitOfWork.CarRepository.AddObject(car);
                }

                unitOfWork.Context.SaveChanges();
            }
            catch (Exception e)
            {
                var logger = serviceProvider.GetRequiredService<ILogger<DbInitializer>>();
                logger.LogError(e, "An error occurred initializing the DB");
            }
        }
    }
}
