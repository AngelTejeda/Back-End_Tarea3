using Tarea_3.DataAccess;

namespace Tarea_3.Models
{
    public abstract class CustomerDTO
    {
        public abstract Customer GetDataBaseCustomerObject();
        public abstract void ModifyDataBaseCustomer(Customer dataBaseCustomer);
    }
}
