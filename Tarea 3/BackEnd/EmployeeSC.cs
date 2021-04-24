using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Tarea_3.DataAccess;
using Tarea_3.Models;

namespace Tarea_3.BackEnd
{
    public static class EmployeeSC
    {
        private static readonly string InstanceName = "employee";

        public static IQueryable<Employee> GetAllEmployees(NorthwindContext dbContext)
        {
            return dbContext.Employees.AsQueryable();
        }

        public static Employee GetEmployeeById(NorthwindContext dbContext, int id)
        {
            try
            {
                return GetAllEmployees(dbContext).First(employee => employee.EmployeeId == id);
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

        private static bool IsSqlException(Exception ex)
        {
            return ex is DbUpdateException
                && ex.InnerException != null
                && ex.InnerException is SqlException;
        }

        public static void AddNewEmployee(NorthwindContext dbContext,  EmployeeDTO newEmployee)
        {
            try
            {
                Employee dataBaseEmployee = newEmployee.GetDataBaseEmployeeObject();

                dbContext.Employees.Add(dataBaseEmployee);
                dbContext.SaveChanges();
            }
            catch (Exception ex) when (IsSqlException(ex))
                //ex is DbUpdateException
                //&& ex.InnerException != null
                //&& ex.InnerException is SqlException
            //)
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

        public static void UpdateEmployee(NorthwindContext dbContext, int id, EmployeeDTO modifiedEmployee)
        {
            try
            {
                Employee dataBaseEmployee = GetEmployeeById(dbContext, id);

                modifiedEmployee.ModifyDataBaseEmployee(dataBaseEmployee);

                dbContext.SaveChanges();
            }
            catch (Exception ex) when (
                ex is DbUpdateException
                && ex.InnerException != null
            )
            {
                ex.SetMessage(DbExceptionMessages.FailedToUpdate(InstanceName, id, ex.InnerException));
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

        public static void DeleteEmployee(NorthwindContext dbContext, int id)
        {
            try
            {
                Employee dataBaseEmployee = GetEmployeeById(dbContext, id);

                dbContext.Employees.Remove(dataBaseEmployee);

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