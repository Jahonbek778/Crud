using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Crud.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly Crudes crud;

        public MarketController(Crudes crud)
        {
            this.crud = crud;
        }

     
        [HttpPost]
        public async Task<IActionResult> Create(ModelDto modelDto)
        {
            var result = await crud.CreateAsync(modelDto);
            
            return Ok(result);
        }

        [HttpGet("{product}")]
        public async Task<IActionResult> Get(string product)
        {
            var result = await crud.GetAsync(product);

            return result is null ? NotFound("Product not found") : Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Model model)
        {
            var result = await crud.UpdateAsync(model);

            return result is null ? NotFound("Product not found") : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await crud.DeleteAsync(id);
            
            return result == false ? NotFound("Product not found") : Ok(true);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await crud.GetAllAsync();

            return Ok(result);
        }
    }
}
