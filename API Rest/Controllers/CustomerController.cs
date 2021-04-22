using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        private static string GetShortExceptionMessage(Exception ex)
        {
            return ex.InnerException + ":" + ex.Message + "\n\nStack Trace\n-----------------\n" + ex.StackTrace;
        }

        private IActionResult InternalServerError(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, GetShortExceptionMessage(ex));
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Customer> customers = new CustomerSC().GetAllCustomers().ToList();

            return Ok(customers);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                Customer customer = new CustomerSC().GetCustomerById(id);

                return Ok(customer);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerBasicDataDTO newCustomer)
        {
            try
            {
                new CustomerSC().AddNewCustomer(newCustomer);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] CustomerBasicDataDTO modifiedCustomer)
        {
            try
            {
                new CustomerSC().UpdateCustomer(id, modifiedCustomer);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                new CustomerSC().DeleteCustomer(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
