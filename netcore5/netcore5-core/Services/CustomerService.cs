using System.Collections.Generic;
using netcore5_core.Infrastructure.Repository;
using netcore5_core.Models;

namespace netcore5_core.Services
{
    public interface ICustomerService {

        List<Customer> Get(int? id);
        Customer Insert(Customer customer);
        Customer Update(Customer customer);
        Customer Delete(int id);

    }
    
    
    public class CustomerService : ICustomerService
    {
        
        readonly ICustomerRepository _customerRepository;
        
        public CustomerService(ICustomerRepository customerRepository) {

            _customerRepository = customerRepository;

        }

        public List<Customer> Get(int? id) {

            return _customerRepository.Get(id);

        }

        public Customer Insert(Customer customer) {

            return _customerRepository.Insert(customer);

        }

        public Customer Update(Customer customer) {

            return _customerRepository.Update(customer);

        }

        public Customer Delete(int id) {

            return _customerRepository.Delete(id);

        }

    }
}