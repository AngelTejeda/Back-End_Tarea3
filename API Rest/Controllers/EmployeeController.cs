using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class EmployeeController : ControllerBase
    {
        private IActionResult InternalServerError(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult Get()
        {
            List<EmployeePersonalInfoDTO> employees = new();

            using (NorthwindContext dbContext = new())
            {
                IQueryable<Employee> dbEmployees = EmployeeSC.GetAllEmployees(dbContext).AsNoTracking();

                foreach(Employee dbEmployee in dbEmployees)
                {
                    employees.Add(new EmployeePersonalInfoDTO(dbEmployee));
                };
            }

            return Ok(employees);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                EmployeePersonalInfoDTO employee;

                using (NorthwindContext dbContext = new())
                {
                    Employee dbEmployee = EmployeeSC.GetEmployeeById(dbContext, id);

                    employee = new(dbEmployee);
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] EmployeePersonalInfoDTO newEmployee)
        {
            int id;

            try
            {
                using (NorthwindContext dbContext = new())
                {
                    id = EmployeeSC.AddNewEmployee(dbContext, newEmployee);
                }

                return Ok("Registered Id: " + id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmployeePersonalInfoDTO modifiedEmployee)
        {
            try
            {
                using (NorthwindContext dbContext = new())
                {
                    EmployeeSC.UpdateEmployee(dbContext, id, modifiedEmployee);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                using (NorthwindContext dbContext = new())
                {
                    EmployeeSC.DeleteEmployee(dbContext, id);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
