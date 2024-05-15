using PizzaShopAPI.Models.DTOs;

namespace PizzaShopAPI.Interfaces
{
    public interface IUserService
    {
        public Task<UserLoginDTO> Login(UserLoginDTO loginDTO);
        public Task<UserRegisterDTO> Register(UserRegisterDTO registerDTO);
    }
}
