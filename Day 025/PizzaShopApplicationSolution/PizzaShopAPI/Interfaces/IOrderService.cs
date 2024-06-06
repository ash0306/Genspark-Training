using PizzaShopAPI.Models.DTOs;

namespace PizzaShopAPI.Interfaces
{
    public interface IOrderService
    {
        public Task<OrderDTO> AddOrder(OrderDTO orderDTO);
        public Task<IEnumerable<OrderDTO>> GetOrders();
    }
}
