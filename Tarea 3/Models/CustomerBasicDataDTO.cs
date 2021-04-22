using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea_3.DataAccess;

namespace Tarea_3.Models
{
    public class CustomerBasicDataDTO : CustomerDTO
    {
        public string Identificador { get; set; }
        public string Empresa { get; set; }

        public CustomerBasicDataDTO()
        {

        }

        public CustomerBasicDataDTO(Customer customer)
        {
            Identificador = customer.CustomerId;
            Empresa = customer.CompanyName;
        }

        public override Customer GetDataBaseCustomerObject()
        {
            return new Customer()
            {
                CustomerId = Identificador,
                CompanyName = Empresa
            };
        }

        public override void ModifyDataBaseCustomer(Customer dataBaseCustomer)
        {
            dataBaseCustomer.CustomerId = Identificador;
            dataBaseCustomer.CompanyName = Empresa;
        }
    }
}
