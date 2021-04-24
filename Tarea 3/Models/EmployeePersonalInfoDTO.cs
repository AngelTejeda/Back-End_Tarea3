using Tarea_3.DataAccess;

namespace Tarea_3.Models
{
    public class EmployeePersonalInfoDTO : EmployeeDTO
    {
        public string HomeAddress { get; set; }

        public EmployeePersonalInfoDTO()
        {

        }

        public EmployeePersonalInfoDTO(string name, string familyName, string homeAddress)
        {
            Name = name;
            FamilyName = familyName;
            HomeAddress = homeAddress;
        }

        public EmployeePersonalInfoDTO(Employee employee)
        {
            Name = employee.FirstName;
            FamilyName = employee.LastName;
            HomeAddress = employee.Address;
        }

        public override Employee GetDataBaseEmployeeObject()
        {
            return new Employee()
            {
                FirstName = Name,
                LastName = FamilyName,
                Address = HomeAddress
            };
        }

        public override void ModifyDataBaseEmployee(Employee dataBaseEmployee)
        {
            dataBaseEmployee.FirstName = Name;
            dataBaseEmployee.LastName = FamilyName;
            dataBaseEmployee.Address = HomeAddress;
        }
    }
}