using Reto1.API.DTO;
using Reto1.API.Entities;
using Reto1.API.Request;

namespace Reto1.API.Interface
{
    public interface ITShirtsService
    {
        Task<List<TShirt>> GetTShirtsAsync();
        Task<TShirt> GetTShirtByIdAsync(int id);
        Task<TShirt> CreateTShirtAsync(TShirtRequest tShirtJson);
        Task<TShirtDto> UpdateTShirtAsync(int id, TShirtDto tShirtJson);
        Task DeleteTShirtAsync(int id);
    }
}
