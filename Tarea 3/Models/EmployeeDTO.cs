using Tarea_3.DataAccess;

namespace Tarea_3.Models
{
    public abstract class EmployeeDTO
    {
        public abstract Employee GetDataBaseEmployeeObject();
        public abstract void ModifyDataBaseEmployee(Employee dataBaseEmployee);
    }
}