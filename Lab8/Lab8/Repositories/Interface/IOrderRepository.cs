using Lab8.Models;

namespace Lab8.Repositories.Interface
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order? GetById(int id);
        void Add(Order order);
        void Delete(int id);
    }
}
