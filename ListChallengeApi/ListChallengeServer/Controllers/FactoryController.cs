using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using Entities;

namespace ListChallengeServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FactoryController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;
        public FactoryController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFactoriesAsync()
        {
            try
            {
                var factories = await _repo.Factory.GetAllFactoriesAsync();

                return Ok(factories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error { ex.Message }");
            }
        }
        [HttpGet("{id}", Name = "FactoryById")]
        public async Task<IActionResult> GetFactoryByIdAsync(Guid id)
        {
            try
            {
                var factory = await _repo.Factory.GetFactoryByIdAsync(id);

                if (factory == null)
                {
                    return NotFound();
                }

                return Ok(factory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error { ex.Message }");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateFactoryAsync(Factory factory)
        {
            try
            {
                var factoryToBeCreated = new Factory {
                    Id = Guid.NewGuid(),
                    RootId = factory.RootId,
                    RangeLow = factory.RangeLow,
                    RangeHigh = factory.RangeHigh
                };

                await _repo.Factory.CreateFactoryAsync(factoryToBeCreated);

                return CreatedAtRoute(routeName: "FactoryById", routeValues: new { id = factoryToBeCreated.Id }, value: factoryToBeCreated);
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error { ex.Message }");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFactoryAsync(Guid id)
        {
            try
            {
                var factoryToBeDeleted = await _repo.Factory.GetFactoryByIdAsync(id);

                if (factoryToBeDeleted == null)
                {
                    return NotFound();
                }

                await _repo.Factory.DeleteFactoryAsync(factoryToBeDeleted);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error { ex.Message }");
            }
            
        }
    }
}