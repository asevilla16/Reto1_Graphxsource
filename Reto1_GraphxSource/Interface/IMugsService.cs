using Reto1.API.DTO;
using Reto1.API.Entities;
using Reto1.API.Request;

namespace Reto1.API.Interface
{
    public interface IMugsService
    {
        Task<List<Mug>> GetMugsAsync();
        Task<Mug> GetMugByIdAsync(int id);
        Task<Mug> CreateMugAsync(MugRequest mugJson);
        Task<MugDto> UpdateMugAsync(int id, MugDto mugJson);
        Task DeleteMugAsync(int id);
    }
}
