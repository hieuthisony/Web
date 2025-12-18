using Lab8.Models;
using Lab8.Repositories.Interface;
using Lab8.Services.Interfaces;

namespace Lab8.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public List<Order> GetAllOrders()
        {
            return _repository.GetAll();
        }

        public Order? GetOrderById(int id)
        {
            return _repository.GetById(id);
        }

        public void CreateOrder(Order order)
        {
            // Có thể thêm logic nghiệp vụ tại đây (ví dụ: gán ngày tạo)
            if (order.OrderDate == default)
            {
                order.OrderDate = System.DateTime.Now;
            }
            _repository.Add(order);
        }

        public void DeleteOrder(int id)
        {
            _repository.Delete(id);
        }
    }
}
