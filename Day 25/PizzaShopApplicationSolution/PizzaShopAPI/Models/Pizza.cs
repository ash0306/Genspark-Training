
namespace PizzaShopAPI.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityInStock { get; set; }
        public string type { get; set; }
        public int price { get; set; }
        public string? Description { get; set; }
    }
}
