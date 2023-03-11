using netcore5_core.Models;

namespace netcore5_webapi.Models.Mappers
{
    public static class CustomerMapper
    {
        public static Customer MappingCustomerForCreate(
            CustomerRequest customerRequest) {

            Customer customer = new Customer {
                Name = customerRequest.Name
            };

            return customer;

        }

        public static Customer MappingCustomerForUpdate(
            CustomerRequest customerRequest, int id) {

            Customer customer = new Customer {
                Id = id,
                Name = customerRequest.Name
            };

            return customer;

        }
    }
}