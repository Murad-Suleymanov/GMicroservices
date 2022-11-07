using System.Net;
using Microsoft.AspNetCore.Mvc;
using GMicroservices.Product.Repositories;
using ProductDao = GMicroservices.Product.Domain.Entities.Product;

namespace GMicroservices.Product.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductController> _logger;
        public ProductController(
            IProductRepository repository,
            ILogger<ProductController> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductDao>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _repository
                .GetProductsAsync();

            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProductDao), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product = await _repository
                .GetProductByIdAsync(id);

            if (product == null)
            {
                _logger.LogError($"Product with id {id}, not found");
                return NotFound();
            }

            return Ok(product);
        }


        [HttpGet]
        [Route("[action]/{category}", Name = "GetProductByCategory")]
        [ProducesResponseType(typeof(IEnumerable<ProductDao>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductByCategory(string category)
        {
            var product = await _repository
                .GetProductsByCategoryAsync(category);


            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductDao), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductDao>> CreateProduct([FromBody] ProductDao product)
        {
            await _repository.CreateProduct(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProductDao), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDao product)
        {
            return Ok(await _repository.UpdateProduct(product));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(ProductDao), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _repository.DeleteProduct(id));
        }
    }
}
