using Reto1.API.DTO;
using Reto1.API.Entities;
using Reto1.API.Request;

namespace Reto1.API.Interface
{
    public interface IPostersService
    {
        Task<List<Poster>> GetPostersAsync();
        Task<Poster> GetPosterByIdAsync(int id);
        Task<Poster> CreatePosterAsync(PosterRequest posterJson);
        Task<PosterDto> UpdatePosterAsync(int id, PosterDto posterJson);
        Task DeletePosterAsync(int id);
    }
}
