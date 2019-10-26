using System;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Contracts;

namespace ListChallengeServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RootController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;
        public RootController(
            IRepositoryWrapper repo
        )
        {
            _repo = repo;
        }
        [HttpGet("{id}", Name = "RootById")]
        public async Task<IActionResult> GetRootAsync(Guid id)
        {
            try
            {
                var root = await _repo.Root.GetRootByIdAsync(id);
                return Ok(root);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error { ex.Message }");
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateRoot()
        {
            try
            {
                var root = new Root { Id = Guid.NewGuid() };

                await _repo.Root.CreateRootAsync(root);

                return CreatedAtRoute(routeName: "RootById",
                                    routeValues: new { id = root.Id},
                                    value: root);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error { ex.Message }");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRootById(Guid id)
        {
            try
            {
                var root = await _repo.Root.GetRootByIdAsync(id);

                if (root == null)
                {
                    return NotFound();
                }

                await _repo.Root.DeleteRootAsync(root);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error { ex.Message }");
            }
            
        }
    }
}