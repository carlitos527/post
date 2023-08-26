using Core.Entities;

namespace Core.Infraestructure
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        Customer? GetById(int idCustomer);
        IEnumerable<Customer> GetAll();
    }
}
