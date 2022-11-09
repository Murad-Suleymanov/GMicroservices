using AutoMapper;
using EventBus.Messages.Events;
using GMicroservices.Parcel.Domain.Entities;
using GMicroservices.Parcel.Repositories;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ParcelController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IParcelRepository _repository;
        public ParcelController(IParcelRepository repository, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _repository = repository;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet("{username}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string username)
        {
            var basket = await _repository.GetParcel(username);
            return Ok(basket ?? new ShoppingCart(username));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
        {
            return Ok(await _repository.UpdateParcel(basket));
        }

        [HttpDelete("{userName}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> DeleteBasket(string userName)
        {
            await _repository.DeleteParcel(userName);
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout([FromBody] ParcelCheckout parcelCheckout)
        {
            // get existing basket with total price 
            // Create basketCheckoutEvent -- Set TotalPrice on basketCheckout eventMessage
            // send checkout event to rabbitmq
            // remove the basket

            // get existing basket with total price
            var parcel = await _repository.GetParcel(parcelCheckout.UserName);
            if (parcel == null)
            {
                return BadRequest();
            }

            // send checkout event to rabbitmq
            var eventMessage = _mapper.Map<ParcelCheckoutEvent>(parcelCheckout);
            eventMessage.TotalPrice = parcel.TotalPrice;
            await _publishEndpoint.Publish(eventMessage);

            // remove the basket
            await _repository.DeleteParcel(parcel.Username);

            return Accepted();
        }
    }
}
