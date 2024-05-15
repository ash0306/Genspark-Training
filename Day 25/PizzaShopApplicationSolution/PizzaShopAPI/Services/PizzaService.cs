using PizzaShopAPI.Exceptions;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;
using PizzaShopAPI.Models.DTOs;

namespace PizzaShopAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<int, Pizza> _repository;

        public PizzaService(IRepository<int, Pizza> repository)
        {
            _repository = repository;
        }

        public async Task<PizzaDTO> AddPizza(PizzaDTO pizzaDTO)
        {
            try
            {
                var pizza = MapPizzaDTOToPizza(pizzaDTO);
                pizza = await _repository.Add(pizza);
                if (pizza == null)
                {
                    throw new UnableToAddPizzaException("Not able to add Pizza at this moment");
                }
                return pizzaDTO;
            }
            catch (Exception ex)
            {
                throw new UnableToAddPizzaException($"Not able to add Pizza at this moment : {ex.Message}");
            }
        }

        private Pizza MapPizzaDTOToPizza(PizzaDTO pizzaDTO)
        {
            Pizza pizza = new Pizza() { 
                Name = pizzaDTO.Name,
                QuantityInStock = pizzaDTO.QuantityInStock,
                price = pizzaDTO.price,
                type = pizzaDTO.type
            };

            return pizza;
        }

        public async Task<IEnumerable<PizzaDTO>> GetAllPizza()
        {
            try
            {
                var pizzas = (await _repository.GetAll()).Where(p => p.QuantityInStock>0);
                if (pizzas == null)
                {
                    throw new NoSuchPizzaException();
                }
                IList<PizzaDTO> pizzaDTOs = new List<PizzaDTO>();
                foreach (Pizza pizza in pizzas)
                {
                    pizzaDTOs.Add(MapPizzaToPizzaDTO(pizza));
                }

                return pizzaDTOs;
            }
            catch (Exception ex)
            {
                throw new NoSuchPizzaException($"No pizza with the mentioned details found: {ex.Message}");
            }
        }

        private PizzaDTO MapPizzaToPizzaDTO(Pizza pizza)
        {
            PizzaDTO pizzaDTO = new PizzaDTO()
            {
                Name = pizza.Name,
                price = pizza.price,
                QuantityInStock = pizza.QuantityInStock,
                type = pizza.type
            };
            return pizzaDTO;
        }

        public async Task<PizzaDTO> UpdatePizzaStock(int id, int stock)
        {
            try { 
                var pizza = await _repository.Get(id);
                if (pizza == null)
                    throw new NoSuchPizzaException();
                pizza.QuantityInStock = stock;
                pizza = await _repository.Update(pizza);
                return MapPizzaToPizzaDTO(pizza);
            }
            catch (Exception ex)
            {
                throw new NoSuchPizzaException($"No pizza with the mentioned details found: {ex.Message}");
            }
        }
    }
}
