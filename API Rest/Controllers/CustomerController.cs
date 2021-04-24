using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Tarea_3.BackEnd;
using Tarea_3.DataAccess;
using Tarea_3.Models;

namespace API_Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IActionResult InternalServerError(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Customer> customers = CustomerSC.GetAllCustomers().ToList();

            return Ok(customers);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                Customer customer = CustomerSC.GetCustomerById(id);

                return Ok(customer);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
                //throw;
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerContactInfoDTO newCustomer)
        {
            try
            {
                CustomerSC.AddNewCustomer(newCustomer);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
                //throw;
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] CustomerContactInfoDTO modifiedCustomer)
        {
            try
            {
                CustomerSC.UpdateCustomer(id, modifiedCustomer);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
                //throw;
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                CustomerSC.DeleteCustomer(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
                //throw;
            }
        }
    }
}
