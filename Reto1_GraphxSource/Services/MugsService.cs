using Reto1.API.DTO;
using Reto1.API.Entities;
using Reto1.API.Interface;
using Reto1.API.Request;

namespace Reto1.API.Services
{
    public class MugsService : IMugsService
    {
        private readonly IGenericRepository<Mug> _mugsRepository;

        public MugsService(IGenericRepository<Mug> mugsRepository)
        {
            _mugsRepository = mugsRepository;
        }

        public async Task<List<Mug>> GetMugsAsync()
        {
            return await _mugsRepository.GetAllAsync();
        }

        public async Task<Mug> GetMugByIdAsync(int id)
        {
            return await _mugsRepository.GetByIdAsync(id);
        }

        public async Task<Mug> CreateMugAsync(MugRequest mugJson)
        {
            var mugToCreate = new Mug
            {
                CapacityInMl = mugJson.CapacityInMl,
                Color = mugJson.Color,
                Price = mugJson.Price,
                Sku = mugJson.Sku
            };
            await _mugsRepository.Insert(mugToCreate);
            await _mugsRepository.Save();
            return mugToCreate;
        }

        public async Task<MugDto> UpdateMugAsync(int id, MugDto mugJson)
        {
            var existingMug = await _mugsRepository.GetByIdAsync(id);

            if (existingMug == null)
            {
                throw new ArgumentNullException(nameof(existingMug));
            }

            existingMug.Sku = mugJson.Sku;
            existingMug.Color = mugJson.Color;
            existingMug.Price = mugJson.Price;
            existingMug.CapacityInMl = mugJson.CapacityInMl;

            _mugsRepository.Update(existingMug);
            await _mugsRepository.Save();
            return mugJson;
        }

        public async Task DeleteMugAsync(int id)
        {
            var existingMug = await _mugsRepository.GetByIdAsync(id);
            if (existingMug == null)
            {
                throw new ArgumentNullException();
            }

            _mugsRepository.DeleteById(existingMug);
            await _mugsRepository.Save();
        }   
    }
}
