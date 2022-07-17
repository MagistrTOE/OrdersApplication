using AutoMapper;
using MediatR;
using MyOrders.Domain;

namespace MyOrders.Application.ActionMethods.Orders.GetOrdersList
{
    public class GetOrderListRequest : IRequest<List<OrderResponse>>
    {
    }

    public class GetOrderListHandler : IRequestHandler<GetOrderListRequest, List<OrderResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public GetOrderListHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderResponse>> Handle(GetOrderListRequest request, CancellationToken cancellationToken)
        {
            var ordersList = await _orderRepository.GetOrdersList();

            return _mapper.Map<List<OrderResponse>>(ordersList);
        }
    }
}
