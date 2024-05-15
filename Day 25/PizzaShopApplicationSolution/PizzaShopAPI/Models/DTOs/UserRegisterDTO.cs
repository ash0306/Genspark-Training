namespace PizzaShopAPI.Models.DTOs
{
    public class UserRegisterDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
