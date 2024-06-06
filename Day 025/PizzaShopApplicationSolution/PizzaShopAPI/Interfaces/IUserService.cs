using PizzaShopAPI.Models.DTOs;

namespace PizzaShopAPI.Interfaces
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<UserRegisterDTO> Register(UserRegisterDTO registerDTO);
    }
}
