namespace CarRental.Models
{
    public class GetFormResponseModel<TModel>
    {
        public TModel Model { get; set; }
        public ResultResponseModel Result { get; } = new ResultResponseModel();
    }

    public class GetFormResponseModel<TModel, TBag>
    {
        public TModel Model { get; set; }
        public TBag Bag { get; set; }
        public ResultResponseModel Result { get; } = new ResultResponseModel();
    }
}
