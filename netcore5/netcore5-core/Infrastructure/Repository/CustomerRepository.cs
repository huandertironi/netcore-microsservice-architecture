using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netcore5_core.Models;

namespace netcore5_core.Infrastructure.Repository
{
    public interface ICustomerRepository {

        List<Customer> Get(int? id);
        Customer Insert(Customer customer);
        Customer Update(Customer customer);
        Customer Delete(int id);

    }
    
    public class CustomerRepository : ICustomerRepository
    {
        
        readonly DatabaseContext _context;

        public CustomerRepository(DatabaseContext context) {

            _context = context;

        }

        public List<Customer> Get(int? id) {
            
            return (
                from c in _context.Customers
                where (id == null || c.Id == id)
                select c
            ).ToList();

        }

        public Customer Insert(Customer customer) {

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;

        }

        public Customer Update(Customer customer) {

            Customer customerToUpdate = (
                from c in _context.Customers
                where c.Id == customer.Id
                select c
            ).FirstOrDefault();

            if (customerToUpdate == null)
                throw new Exception("except_customer_not_found");

            _context.Customers.Update(customerToUpdate);
            _context.SaveChanges();

            return customerToUpdate;

        }

        public Customer Delete(int id) {

            Customer customerToDelete = (
                from c in _context.Customers
                where c.Id == id
                select c
            ).FirstOrDefault();

            if (customerToDelete == null)
                throw new Exception("except_customer_not_found");

            _context.Customers.Remove(customerToDelete);
            _context.SaveChanges();

            return customerToDelete;

        }
    }
}