using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reto1.API.DTO;
using Reto1.API.Entities;
using Reto1.API.Interface;
using Reto1.API.Request;

namespace Reto1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _ordersService.GetOrdersAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            return await _ordersService.GetOrderByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDto>> PutOrder(int id, OrderDto order)
        {
            return await _ordersService.UpdateOrderAsync(id, order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(OrderRequest order)
        {
            return await _ordersService.CreateOrderAsync(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _ordersService.DeleteOrderAsync(id);
            return Ok("Record deleted");
        }
    }
}
