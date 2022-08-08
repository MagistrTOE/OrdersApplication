using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyOrders.Application.ActionMethods.Orders.Create;
using MyOrders.Application.ActionMethods.Orders.GetOrdersList;

namespace MyOrders.Web.Api.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<List<OrderResponse>> GetListOrders()
        {
            return await _mediator.Send(new GetOrderListRequest());
        }

        [HttpPost()]
        public async Task<CreatedOrderResponse> CreateOrder([FromBody] CreatedOrderRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
