namespace Shoping.Aggregator.Models
{
    public class ShoppingModel
    {
        public string UserName { get; set; }
        public ParcelModel ParcelWithProducts { get; set; }
        public IEnumerable<OrderResponseModel> Orders { get; set; }
    }
}
