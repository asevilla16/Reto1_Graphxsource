using Microsoft.EntityFrameworkCore;
using Reto1.API.DTO;
using Reto1.API.Entities;
using Reto1.API.Interface;
using Reto1.API.Request;

namespace Reto1.API.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IGenericRepository<Order> _ordersRepository;
        private readonly IGenericRepository<Attachment> _attachmentsRepository;

        public OrdersService(IGenericRepository<Order> ordersRepository, IGenericRepository<Attachment> attachmentsRepository)
        {
            _attachmentsRepository = attachmentsRepository;
            _ordersRepository = ordersRepository;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _ordersRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await (from o in _ordersRepository.DbSet()
                               .Include(m => m.Mug)
                               .Include(t => t.TShirt)
                               .Include(p => p.Poster)
                               where o.Id == id
                               select o).FirstOrDefaultAsync();

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            var attachments = await (from a in _attachmentsRepository.DbSet()
                                     where a.OrderId == id
                                     select a).ToListAsync();

            if (attachments.Any())
            {
                order.Attachments = attachments;
            }

            return order;
        }

        public async Task<Order> CreateOrderAsync(OrderRequest orderJson)
        {
            var orderToCreate = new Order
            {
                Client = orderJson.Client,
                Description = orderJson.Description,
                TShirtId = orderJson.TShirtId,
                MugId = orderJson.MugId,
                PosterId = orderJson.PosterId,
                Status = orderJson.Status,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            await _ordersRepository.Insert(orderToCreate);
            await _ordersRepository.Save();
            return orderToCreate;
        }

        public async Task<OrderDto> UpdateOrderAsync(int id, OrderDto orderJson)
        {
            var existingOrder = await _ordersRepository.GetByIdAsync(id);

            if (existingOrder == null)
            {
                throw new ArgumentNullException(nameof(existingOrder));
            }

            existingOrder.Client = orderJson.Client;
            existingOrder.Description = orderJson.Description;
            existingOrder.TShirtId = orderJson.TShirtId;
            existingOrder.MugId = orderJson.MugId;
            existingOrder.PosterId = orderJson.PosterId;
            existingOrder.Status = orderJson.Status;
            existingOrder.UpdatedAt = DateTime.UtcNow;

            _ordersRepository.Update(existingOrder);
            await _ordersRepository.Save();
            return orderJson;
        }

        public async Task DeleteOrderAsync(int id)
        {
            var existingOrder = await _ordersRepository.GetByIdAsync(id);
            if (existingOrder == null)
            {
                throw new ArgumentNullException();
            }

            _ordersRepository.DeleteById(existingOrder);
            await _ordersRepository.Save();
        }
    }
}
