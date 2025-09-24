using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reto1.API;
using Reto1.API.DTO;
using Reto1.API.Entities;
using Reto1.API.Interface;
using Reto1.API.Request;

namespace Reto1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostersController : ControllerBase
    {
        private readonly IPostersService _postersService;

        public PostersController(IPostersService postersService)
        {
            _postersService = postersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poster>>> GetPosters()
        {
            return await _postersService.GetPostersAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Poster>> GetPoster(int id)
        {
            return await _postersService.GetPosterByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PosterDto>> PutPoster(int id, PosterDto poster)
        {
            return await _postersService.UpdatePosterAsync(id, poster);
        }

        [HttpPost]
        public async Task<ActionResult<Poster>> PostPoster(PosterRequest poster)
        {
            return await _postersService.CreatePosterAsync(poster);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoster(int id)
        {
            await _postersService.DeletePosterAsync(id);
            return Ok("Record deleted");
        }
    }
}
