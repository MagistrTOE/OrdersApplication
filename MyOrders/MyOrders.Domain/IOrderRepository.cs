namespace MyOrders.Domain
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersList();
        Task Create(Order order);
    }
}
