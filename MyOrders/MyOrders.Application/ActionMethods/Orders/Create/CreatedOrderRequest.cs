using AutoMapper;
using MediatR;
using MyOrders.Domain;

namespace MyOrders.Application.ActionMethods.Orders.Create
{
    public class CreatedOrderRequest : IRequest<CreatedOrderResponse>
    {
        public string SenderCity { get; set; }
        public string SenderAddress { get; set; }
        public string RecipientCity { get; set; }
        public string RecipientAddress { get; set; }
        public double Weight { get; set; }
        public DateTime RecivedDate { get; set; }
    }

    public class CreateOrderHandler : IRequestHandler<CreatedOrderRequest, CreatedOrderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<CreatedOrderResponse> Handle(CreatedOrderRequest request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            await _orderRepository.Create(order);

            return _mapper.Map<CreatedOrderResponse>(order);
        }
    }
}
