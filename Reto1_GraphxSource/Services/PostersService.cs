using Reto1.API.DTO;
using Reto1.API.Entities;
using Reto1.API.Interface;
using Reto1.API.Request;

namespace Reto1.API.Services
{
    public class PostersService : IPostersService
    {
        private readonly IGenericRepository<Poster> _postersRepository;

        public PostersService(IGenericRepository<Poster> postersRepository)
        {
            _postersRepository = postersRepository;
        }

        public async Task<List<Poster>> GetPostersAsync()
        {
            return await _postersRepository.GetAllAsync();
        }

        public async Task<Poster> GetPosterByIdAsync(int id)
        {
            return await _postersRepository.GetByIdAsync(id);
        }

        public async Task<Poster> CreatePosterAsync(PosterRequest posterJson)
        {
            var posterToCreate = new Poster
            {
                HeightCm = posterJson.HeightCm,
                WidthCm = posterJson.WidthCm,
                PaperType = posterJson.PaperType,
                Price = posterJson.Price,
                Sku = posterJson.Sku
            };
            await _postersRepository.Insert(posterToCreate);
            await _postersRepository.Save();
            return posterToCreate;
        }

        public async Task<PosterDto> UpdatePosterAsync(int id, PosterDto posterJson)
        {
            var existingPoster = await _postersRepository.GetByIdAsync(id);

            if (existingPoster == null)
            {
                throw new ArgumentNullException(nameof(existingPoster));
            }

            existingPoster.Sku = posterJson.Sku;
            existingPoster.HeightCm = posterJson.HeightCm;
            existingPoster.WidthCm = posterJson.WidthCm;
            existingPoster.PaperType = posterJson.PaperType;
            existingPoster.Price = posterJson.Price;

            _postersRepository.Update(existingPoster);
            await _postersRepository.Save();
            return posterJson;
        }

        public async Task DeletePosterAsync(int id)
        {
            var existingPoster = await _postersRepository.GetByIdAsync(id);
            if (existingPoster == null)
            {
                throw new ArgumentNullException();
            }

            _postersRepository.DeleteById(existingPoster);
            await _postersRepository.Save();
        }
    }
}
