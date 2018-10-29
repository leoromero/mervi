using Mervi.Core;
using Mervi.Model.Catalogue;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mervi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _service;

        public ProductsController(IProductsService service)
        {
            _service = service;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> Get()
        {
            return Ok(await _service.GetAsync());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> Get(long id)
        {
            return Ok(await _service.GetAsync(id));
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] ProductCreateModel value)
        {
            await _service.CreateAsync(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(long id, [FromBody] ProductUpdateModel value)
        {
            await _service.UpdateAsync(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            await _service.DeleteAsync(id);
        }
    }
}
