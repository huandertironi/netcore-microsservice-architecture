using netcore7_core.Models;
using netcore7_webapi.Models.Mappers;

namespace netcore7_webapi.Models
{
    public class CustomerRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public Customer BuilderCustomerAggregate() => 
            CustomerMapper.MappingCustomerForCreate(this);

        public Customer BuilderCustomerAggregate(int id) => 
            CustomerMapper.MappingCustomerForUpdate(this, id);
    }
}