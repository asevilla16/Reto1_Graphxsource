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
    public class TShirtsController : ControllerBase
    {
        private readonly ITShirtsService _shirtsService;

        public TShirtsController(ITShirtsService shirtsService)
        {
            _shirtsService = shirtsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TShirt>>> GetTShirts()
        {
            return await _shirtsService.GetTShirtsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TShirt>> GetTShirt(int id)
        {
            return await _shirtsService.GetTShirtByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TShirtDto>> PutTShirt(int id, TShirtDto tshirt)
        {
            return await _shirtsService.UpdateTShirtAsync(id, tshirt);
        }

        [HttpPost]
        public async Task<ActionResult<TShirt>> PostTShirt(TShirtRequest tshirt)
        {
            return await _shirtsService.CreateTShirtAsync(tshirt);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTShirt(int id)
        {
            await _shirtsService.DeleteTShirtAsync(id);
            return Ok("Record deleted");
        }
    }
}
