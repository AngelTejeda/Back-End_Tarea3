using Tarea_3.DataAccess;

namespace Tarea_3.Models
{
    public class EmployeeContactDataDTO : EmployeeDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }

        public EmployeeContactDataDTO()
        {

        }

        public EmployeeContactDataDTO(Employee employee)
        {
            Nombre = employee.FirstName;
            Apellido = employee.LastName;
            Direccion = employee.Address;
            Ciudad = employee.City;
            Pais = employee.Country;
            Telefono = employee.HomePhone;
        }

        public override Employee GetDataBaseEmployeeObject()
        {
            return new Employee()
            {
                FirstName = Nombre,
                LastName = Apellido,
                Address = Direccion,
                City = Ciudad,
                Country = Pais,
                HomePhone = Telefono
            };
        }

        public override void ModifyDataBaseEmployee(Employee dataBaseEmployee)
        {
            dataBaseEmployee.FirstName = Nombre;
            dataBaseEmployee.LastName = Apellido;
            dataBaseEmployee.Address = Direccion;
            dataBaseEmployee.City = Ciudad;
            dataBaseEmployee.Country = Pais;
            dataBaseEmployee.HomePhone = Telefono;
        }
    }
}