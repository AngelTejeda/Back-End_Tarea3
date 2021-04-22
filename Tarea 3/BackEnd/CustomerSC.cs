using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Tarea_3.DataAccess;
using Tarea_3.Models;

namespace Tarea_3.BackEnd
{
    public class CustomerSC : BaseSC
    {
        private readonly string InstanceName = "cliente";

        public IQueryable<Customer> GetAllCustomers()
        {
            IQueryable<Customer> customers;

            using (NorthwindContext context = new())
            {
                customers = context.Customers.AsQueryable();
            }

            return customers;
            //return dbContext.Customers.AsQueryable();
        }

        public Customer GetCustomerById(string id)
        {
            try
            {
                return GetAllCustomers().First(customer => customer.CustomerId == id);
            }
            catch (ArgumentNullException ex)
            {
                ex.SetMessage(DbExceptionMessages.FieldIsRequired("id"));
                throw;
            }
            catch (InvalidOperationException ex)
            {
                ex.SetMessage(DbExceptionMessages.InstanceNotFound(InstanceName, id));
                throw;
            }
        }

        public void AddNewCustomer(CustomerDTO newCustomer)
        {
            try
            {
                Customer dataBaseCustomer = newCustomer.GetDataBaseCustomerObject();

                dbContext.Customers.Add(dataBaseCustomer);
                dbContext.SaveChanges();
            }
            catch (Exception ex) when (
                ex is DbUpdateException || ex is DbUpdateConcurrencyException
            )
            {
                ex.SetMessage(DbExceptionMessages.FailedToAdd(InstanceName));
                throw;
            }
        }

        public void UpdateCustomer(string id, CustomerDTO modifiedCustomer)
        {
            try
            {
                Customer dataBaseCustomer = GetCustomerById(id);

                modifiedCustomer.ModifyDataBaseCustomer(dataBaseCustomer);

                dbContext.SaveChanges();
            }
            catch (Exception ex) when (
                ex is DbUpdateException || ex is DbUpdateConcurrencyException
            )
            {
                ex.SetMessage(DbExceptionMessages.FailedToUpdate(InstanceName));
                throw;
            }
        }

        public void DeleteCustomer(string id)
        {
            try
            {
                Customer dataBaseCustomer = GetCustomerById(id);

                dbContext.Customers.Remove(dataBaseCustomer);

                dbContext.SaveChanges();
            }
            catch (SqlException ex)
            {
                ex.SetMessage("Conflicto de llave foránea");
                throw;
            }
            catch (Exception ex) when (
                ex is DbUpdateException || ex is DbUpdateConcurrencyException
            )
            {
                ex.SetMessage(DbExceptionMessages.FailedToDelete(InstanceName, id));
                throw;
            }
        }
    }
}
