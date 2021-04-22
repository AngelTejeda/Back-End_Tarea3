using Microsoft.AspNetCore.Mvc;
using Tarea_3.BackEnd;
using Tarea_3.Models;
using Tarea_3.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeSC EmployeeSC = new();

        // GET: api/<EmployeeController>
        [HttpGet]
        public IQueryable<Employee> Get()
        {
            return EmployeeSC.GetAllEmployees();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return EmployeeSC.GetEmployeeById(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] EmployeeBasicDataDTO newEmployee)
        {
            EmployeeSC.AddNewEmployee(newEmployee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeDTO modifiedEmployee)
        {
            EmployeeSC.UpdateEmployee(id, modifiedEmployee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            EmployeeSC.DeleteEmployee(id);
        }
    }
}
