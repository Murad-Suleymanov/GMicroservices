using AutoMapper;
using EventBus.Messages.Events;
using GMicroservices.Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using MassTransit;
using MediatR;

namespace GMicroservices.Ordering.WebApi.EventBusConsumer
{
    public class ParcelCheckoutConsumer : IConsumer<ParcelCheckoutEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<ParcelCheckoutEvent> _logger;

        public ParcelCheckoutConsumer(IMediator mediator, IMapper mapper, ILogger<ParcelCheckoutEvent> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<ParcelCheckoutEvent> context)
        {
            var command = _mapper.Map<CheckoutOrderCommand>(context.Message);
            var result = await _mediator.Send(command);

            _logger.LogInformation("ParcelCheckoutEvent consumed successfully. Created Order Id : {newOrderId}", result);
        }
    }
}
