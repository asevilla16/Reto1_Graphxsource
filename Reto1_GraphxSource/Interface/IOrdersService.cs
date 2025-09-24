using Reto1.API.DTO;
using Reto1.API.Entities;
using Reto1.API.Request;

namespace Reto1.API.Interface
{
    public interface IOrdersService
    {
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> CreateOrderAsync(OrderRequest orderJson);
        Task<OrderDto> UpdateOrderAsync(int id, OrderDto orderJson);
        Task DeleteOrderAsync(int id);
    }
}
