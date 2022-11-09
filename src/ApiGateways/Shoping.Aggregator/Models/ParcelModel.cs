namespace Shoping.Aggregator.Models
{
    public class ParcelModel
    {
        public string UserName { get; set; }
        public List<ParcelItemExtendedModel> Items { get; set; } = new List<ParcelItemExtendedModel>();
        public decimal TotalPrice { get; set; }
    }
}
