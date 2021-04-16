using System.Collections.Generic;
using System.Linq;
using Tarea_3.BackEnd;
using Tarea_3.DataAccess;
using Tarea_3.Models;

namespace Tarea_3
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeSC employeeSC = new();

            //Consulta original reescrita.
            List<EmployeeBasicDataDTO> empleados = employeeSC
                .GetAllEmployees()
                .Select(employee => new EmployeeBasicDataDTO(employee))
                .ToList();


            #region Liskov Substitution Principle

            EmployeeDTO basicInfoEmployee = new EmployeeBasicDataDTO()
            {
                Nombre = "Pedro",
                Apellido = "Hernandez",
                Puesto = "Programador"
            };

            EmployeeDTO contactInfoEmployee = new EmployeeContactDataDTO()
            {
                Nombre = "Melisa",
                Apellido = "Perez",
                Ciudad = "Monterrey",
                Pais = "México",
                Direccion = "Anáhuac",
                Telefono = "8182838485"
            };

            #endregion

            #region Open-Closed

            employeeSC.AddNewEmployee(basicInfoEmployee);
            employeeSC.AddNewEmployee(contactInfoEmployee);

            #endregion
        }
    }
}