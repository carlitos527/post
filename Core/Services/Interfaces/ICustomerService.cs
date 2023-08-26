using Core.Entities;

namespace Core.Services.Interfaces
{
    public interface ICustomerService
    {
        void CreateCustomer(Customer customer);

        void DeleteCustomer(int id);

        IEnumerable<Customer>? GetAll();

        Customer? GetById(int idCustomer);

        void UpdateCustomer(int id, Customer customer);
    }
}
