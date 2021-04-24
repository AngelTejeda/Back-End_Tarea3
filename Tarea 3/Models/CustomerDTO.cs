using Tarea_3.DataAccess;

namespace Tarea_3.Models
{
    public abstract class CustomerDTO
    {
        public string Id { get; set; }
        public string Company { get; set; }

        public abstract Customer GetDataBaseCustomerObject();
        public abstract void ModifyDataBaseCustomer(Customer dataBaseCustomer);
    }
}
