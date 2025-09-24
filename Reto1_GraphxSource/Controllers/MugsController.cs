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
    public class MugsController : ControllerBase
    {
        private readonly IMugsService _mugsService;

        public MugsController(IMugsService mugsService)
        {
            _mugsService = mugsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mug>>> GetMugs()
        {
            return await _mugsService.GetMugsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mug>> GetMug(int id)
        {
            return await _mugsService.GetMugByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MugDto>> PutMug(int id, MugDto mug)
        {
            return await _mugsService.UpdateMugAsync(id, mug);
        }

        [HttpPost]
        public async Task<ActionResult<Mug>> PostMug(MugRequest mug)
        {
            return await _mugsService.CreateMugAsync(mug);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMug(int id)
        {
            await _mugsService.DeleteMugAsync(id);
            return Ok("Record deleted");
        }
    }
}
