using System.Net;
using Microsoft.AspNetCore.Mvc;
using GMicroservices.Parcel.Repositories;
using GMicroservices.Parcel.Domain.Entities;

namespace GMicroservices.Parcel.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ParcelController : ControllerBase
    {
        private readonly IParcelRepository _repository;

        public ParcelController(IParcelRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{username}", Name = "GetParcel")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetParcel(string username)
        {
            var basket = await _repository.GetParcel(username);
            return Ok(basket ?? new ShoppingCart(username));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateParcel([FromBody] ShoppingCart basket)
        {
            return Ok(await _repository.UpdateParcel(basket));
        }

        [HttpDelete("{userName}", Name = "DeleteParcel")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> DeleteParcel(string userName)
        {
            await _repository.DeleteParcel(userName);
            return Ok();
        }
    }
}
