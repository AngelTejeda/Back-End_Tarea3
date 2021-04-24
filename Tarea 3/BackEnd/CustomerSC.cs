﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tarea_3.DataAccess;
using Tarea_3.Models;

namespace Tarea_3.BackEnd
{
    public static class CustomerSC
    {
        private static readonly string InstanceName = "client";
        private static readonly NorthwindContext dbContext = new();

        public static IQueryable<Customer> GetAllCustomers()
        {
            return dbContext.Customers.AsQueryable();
        }

        public static Customer GetCustomerById(string id)
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

        public static void AddNewCustomer(CustomerDTO newCustomer)
        {
            try
            {
                Customer dataBaseCustomer = newCustomer.GetDataBaseCustomerObject();

                dbContext.Customers.Add(dataBaseCustomer);
                dbContext.SaveChanges();
            }
            catch (Exception ex) when (
                ex is DbUpdateException
                && ex.InnerException != null
            )
            {
                ex.SetMessage(DbExceptionMessages.FailedToAdd(InstanceName, ex.InnerException));
                throw;
            }
            catch (Exception ex) when (
                ex is DbUpdateException
                || ex is DbUpdateConcurrencyException
            )
            {
                ex.SetMessage(DbExceptionMessages.UnexpectedFailure(ex));
                throw;
            }
        }

        public static void UpdateCustomer(string id, CustomerDTO modifiedCustomer)
        {
            try
            {
                Customer dataBaseCustomer = GetCustomerById(id);

                modifiedCustomer.ModifyDataBaseCustomer(dataBaseCustomer);

                dbContext.SaveChanges();
            }
            catch (Exception ex) when (
                ex is DbUpdateException
                && ex.InnerException != null
            )
            {
                ex.SetMessage(DbExceptionMessages.FailedToUpdate(InstanceName, id, ex));
                throw;
            }
            catch (Exception ex) when (
                ex is DbUpdateException
                || ex is DbUpdateConcurrencyException
            )
            {
                ex.SetMessage(DbExceptionMessages.UnexpectedFailure(ex));
                throw;
            }
        }

        public static void DeleteCustomer(string id)
        {
            try
            {
                Customer dataBaseCustomer = GetCustomerById(id);

                dbContext.Customers.Remove(dataBaseCustomer);

                dbContext.SaveChanges();
            }
            catch (Exception ex) when (
                ex is DbUpdateException
                && ex.InnerException != null
            )
            {
                ex.SetMessage(DbExceptionMessages.FailedToDelete(InstanceName, id, ex.InnerException));
                throw;
            }
            catch (Exception ex) when (
                ex is DbUpdateException
                || ex is DbUpdateConcurrencyException
            )
            {
                ex.SetMessage(DbExceptionMessages.UnexpectedFailure(ex));
                throw;
            }
        }
    }
}
