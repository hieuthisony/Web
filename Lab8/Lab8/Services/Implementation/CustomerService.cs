using Lab8.Models;
using Lab8.Repositories.Interface;
using Lab8.Services.Interfaces;

namespace Lab8.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public List<Customer> GetAllCustomers() { return _repository.GetAll(); }
        public Customer? GetCustomerById(int id) { return _repository.GetById(id); }
        public void CreateCustomer(Customer customer) { _repository.Add(customer); }
        public void UpdateCustomer(Customer customer) { _repository.Update(customer); }
        public void DeleteCustomer(int id) { _repository.Delete(id); }
    }
}
