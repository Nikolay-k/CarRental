namespace CarRental.Models
{
    public sealed class ResultResponseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
    }
}
