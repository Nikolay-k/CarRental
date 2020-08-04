using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models.OrderViewModels
{
    public class OrderViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int? UserId { get; set; }
        public string UserName { get; set; }

        [Required]
        public int? CarId { get; set; }
        public string CarName { get; set; }

        [Required]
        public DateTime? RentalStartDate { get; set; }

        [Required]
        public DateTime? RentalEndDate { get; set; }

        [StringLength(200)]
        public string Comment { get; set; }
    }

    public class OrderViewBag
    {
        public SelectItemViewModel[] Users { get; set; }
        public SelectItemViewModel[] Cars { get; set; }
    }

    public class OrderListViewModel
    {
        public OrderViewModel[] Orders { get; set; }
    }
}
