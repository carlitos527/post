using Core.Entities;
using Core.Infraestructure;
using Core.Services.Interfaces;

namespace Core.Services.Imp
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPostRepository _postRepository;

        public CustomerService(ICustomerRepository customerRepository, IPostRepository postRepository) 
        { 
            _customerRepository = customerRepository;
            _postRepository = postRepository;
        }

        public void CreateCustomer(Customer customer)
        {
            var customers = _customerRepository.GetAll().Where(x=>x.Name == customer.Name);

            if(!customers.Any())
            {
                _customerRepository.CreateCustomer(customer);
            }
        }

        public void DeleteCustomer(int id)
        {
            var customerEliminated = _customerRepository.GetById(id);

            if (customerEliminated != null)
            {
                var posts = _postRepository.GetAllPost().Where(x => x.CustomerId == id);
                _postRepository.DeletePost(posts);

                _customerRepository.DeleteCustomer(customerEliminated);
            }  
        }

        public IEnumerable<Customer>? GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Customer? GetById(int idCustomer)
        {
            return _customerRepository.GetById(idCustomer);
        }

        public void UpdateCustomer(int id, Customer customer)
        {
            var currentCustomer = _customerRepository.GetById(id);

            if (currentCustomer != null)
            {
                currentCustomer.Name = customer.Name;
                _customerRepository.UpdateCustomer(currentCustomer);
            }
        }
    }
}
