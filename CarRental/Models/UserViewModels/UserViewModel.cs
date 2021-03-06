﻿using System;

namespace CarRental.Models.UserViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string DrivingLicenseNumber { get; set; }
    }

    public class UserListViewModel
    {
        public UserViewModel[] Users { get; set; }
    }
}
