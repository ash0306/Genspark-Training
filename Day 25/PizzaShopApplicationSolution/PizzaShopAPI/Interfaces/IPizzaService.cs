using PizzaShopAPI.Models;
using PizzaShopAPI.Models.DTOs;

namespace PizzaShopAPI.Interfaces
{
    public interface IPizzaService
    {
        public Task<PizzaDTO> AddPizza(PizzaDTO pizzaDTO);

        public Task<PizzaDTO> UpdatePizzaStock(int id, int stock);

        public Task<IEnumerable<PizzaDTO>> GetAllPizza();
    }
}
