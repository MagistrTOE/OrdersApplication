using AutoMapper;
using MyOrders.Application.ActionMethods.Orders.Create;
using MyOrders.Application.ActionMethods.Orders.GetOrdersList;
using MyOrders.Domain;

namespace MyOrders.Application.ActionMethods.Orders
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<Order, CreatedOrderResponse>();
            CreateMap<CreatedOrderRequest, Order>();
            CreateMap<Order, OrderResponse>();
        }
    }
}