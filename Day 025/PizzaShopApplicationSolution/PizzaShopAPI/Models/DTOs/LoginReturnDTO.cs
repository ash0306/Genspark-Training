namespace PizzaShopAPI.Models.DTOs
{
    public class LoginReturnDTO
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
