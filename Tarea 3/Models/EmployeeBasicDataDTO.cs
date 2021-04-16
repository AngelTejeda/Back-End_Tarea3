using Tarea_3.DataAccess;

namespace Tarea_3.Models
{
    public class EmployeeBasicDataDTO : EmployeeDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Puesto { get; set; }

        public EmployeeBasicDataDTO()
        {

        }

        public EmployeeBasicDataDTO(Employee employee)
        {
            Nombre = employee.FirstName;
            Apellido = employee.LastName;
            Puesto = employee.Title;
        }

        public override Employee GetDataBaseEmployeeObject()
        {
            return new Employee()
            {
                FirstName = Nombre,
                LastName = Apellido,
                Title = Puesto
            };
        }

        public override void ModifyDataBaseEmployee(Employee dataBaseEmployee)
        {
            dataBaseEmployee.FirstName = Nombre;
            dataBaseEmployee.LastName = Apellido;
            dataBaseEmployee.Title = Puesto;
        }
    }
}