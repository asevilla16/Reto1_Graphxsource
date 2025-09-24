using Reto1.API.DTO;
using Reto1.API.Entities;
using Reto1.API.Interface;
using Reto1.API.Request;

namespace Reto1.API.Services
{
    public class TShirtsService : ITShirtsService
    {
        private readonly IGenericRepository<TShirt> _tShirtsRepository;

        public TShirtsService(IGenericRepository<TShirt> tShirtsRepository)
        {
            _tShirtsRepository = tShirtsRepository;
        }

        public async Task<TShirt> CreateTShirtAsync(TShirtRequest tShirtJson)
        {
            var tShirtToCreate = new TShirt
            {
                Size = tShirtJson.Size,
                Color = tShirtJson.Color,
                Price = tShirtJson.Price,
                Sku = tShirtJson.Sku
            };

            await _tShirtsRepository.Insert(tShirtToCreate);
            await _tShirtsRepository.Save();
            return tShirtToCreate;
        }

        public async Task DeleteTShirtAsync(int id)
        {
            var tShirtToDelete = await _tShirtsRepository.GetByIdAsync(id);
            if (tShirtToDelete != null)
            {
                _tShirtsRepository.DeleteById(tShirtToDelete);
                await _tShirtsRepository.Save();
            }
        }

        public async Task<TShirt> GetTShirtByIdAsync(int id)
        {
            return await _tShirtsRepository.GetByIdAsync(id);
        }

        public async Task<List<TShirt>> GetTShirtsAsync()
        {
            return await _tShirtsRepository.GetAllAsync();
        }

        public async Task<TShirtDto> UpdateTShirtAsync(int id, TShirtDto tShirtJson)
        {
            var tShirtToUpdate = await _tShirtsRepository.GetByIdAsync(id);
            if (tShirtToUpdate != null)
            {
                tShirtToUpdate.Size = tShirtJson.Size;
                tShirtToUpdate.Color = tShirtJson.Color;
                tShirtToUpdate.Price = tShirtJson.Price;
                tShirtToUpdate.Sku = tShirtJson.Sku;

                _tShirtsRepository.Update(tShirtToUpdate);
                await _tShirtsRepository.Save();
            }
            return tShirtJson;
        }
    }
}
