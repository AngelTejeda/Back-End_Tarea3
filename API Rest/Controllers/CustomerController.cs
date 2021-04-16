using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Tarea_3.BackEnd;
using Tarea_3.DataAccess;
using Tarea_3.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerSC customerSC = new();

        // GET: api/<CustomerController>
        [HttpGet]
        public IQueryable<Customer> Get()
        {
            return customerSC.GetAllCustomers();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer Get(string id)
        {
            return customerSC.GetCustomerById(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] CustomerDTO newCustomer)
        {
            customerSC.AddNewCustomer(newCustomer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] CustomerDTO modifiedCustomer)
        {
            customerSC.UpdateCustomer(id, modifiedCustomer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            customerSC.DeleteCustomer(id);
        }
    }
}
