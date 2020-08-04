namespace CarRental.Models.CarViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Class { get; set; }
        public ushort IssueYear { get; set; }
        public string RegistrationNumber { get; set; }
    }

    public class CarListViewModel
    {
        public CarViewModel[] Cars { get; set; }
    }
}
