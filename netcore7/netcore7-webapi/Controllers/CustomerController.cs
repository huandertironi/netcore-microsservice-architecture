using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using netcore7_core.Models;
using netcore7_core.Services;
using netcore7_webapi.Models;

namespace netcore7_webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    [Authorize(Roles = "RoleName")]
    public IActionResult Get([FromQuery]int? id)
    {
        try {

            return Ok(_customerService.Get(id));

        } catch (Exception e) {

            return BadRequest(e.Message);

        }
    }

    [HttpPost]
    [Authorize(Roles = "RoleName")]
    public IActionResult Insert([FromBody]CustomerRequest customerRequest) {

        try {

            Customer customer = customerRequest.BuilderCustomerAggregate();

            return Ok(_customerService.Insert(customer));

        } catch (Exception e) {

            return BadRequest(e.Message);

        }

    }

    [HttpPut]
    [Authorize(Roles = "RoleName")]
    [Route("{id}")]
    public IActionResult Update([FromRoute]int id, [FromBody]CustomerRequest customerRequest) {

        try {

            if (id == 0)
                throw new Exception("except_id_required");

            Customer customer = customerRequest.BuilderCustomerAggregate(id);

            return Ok(_customerService.Update(customer));

        } catch (Exception e) {

            return BadRequest(e.Message);

        }

    }

    [HttpDelete]
    [Authorize(Roles = "RoleName")]
    [Route("{id}")]
    public IActionResult Delete(int id) {

        try {

            if (id == 0)
                throw new Exception("except_id_required");

            return Ok(_customerService.Delete(id));

        } catch (Exception e) {

            return BadRequest(e.Message);

        }

    }
}
