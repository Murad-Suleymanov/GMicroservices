using Microsoft.AspNetCore.Mvc;
using Shoping.Aggregator.Models;
using Shoping.Aggregator.Services;
using System.Net;

namespace Shoping.Aggregator.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShoppingController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IParcelService _parcelService;
        private readonly IOrderService _orderService;

        public ShoppingController(IProductService productService, IParcelService parcelService, IOrderService orderService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _parcelService = parcelService ?? throw new ArgumentNullException(nameof(parcelService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [HttpGet("{userName}", Name = "GetShopping")]
        [ProducesResponseType(typeof(ShoppingModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingModel>> GetShopping(string userName)
        {
            // get basket with username
            // iterate basket items and consume products with basket item productId member
            // map product related members into basketitem dto with extended columns
            // consume ordering microservices in order to retrieve order list
            // return root ShoppngModel dto class which including all responses

            var parcel = await _parcelService.GetParcel(userName);

            foreach (var item in parcel.Items)
            {
                var product = await _productService.GetProduct(item.ProductId);

                // set additional product fields onto basket item
                item.ProductName = product.Name;
                item.Category = product.Category;
                item.Summary = product.Summary;
                item.Description = product.Description;
                item.ImageFile = product.ImageFile;
            }

            var orders = await _orderService.GetOrdersByUserName(userName);

            var shoppingModel = new ShoppingModel
            {
                UserName = userName,
                ParcelWithProducts = parcel,
                Orders = orders
            };

            return Ok(shoppingModel);
        }
    }
}
