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

        public static int AddNewEmployee(NorthwindContext dbContext,  EmployeeDTO newEmployee)
        {
            try
            {
                Employee dataBaseEmployee = newEmployee.GetDataBaseEmployeeObject();

                dbContext.Employees.Add(dataBaseEmployee);
                dbContext.SaveChanges();

                return dataBaseEmployee.EmployeeId;
            }
            catch (Exception ex) when (ExceptionTypes.IsSqlException(ex))
            {
                ex.SetMessage(DbExceptionMessages.FailedToAdd(InstanceName, ex.InnerException));
                throw;
            }
            catch (Exception ex) when (ExceptionTypes.IsDbException(ex))
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
            catch (Exception ex) when (ExceptionTypes.IsSqlException(ex))
            {
                ex.SetMessage(DbExceptionMessages.FailedToUpdate(InstanceName, id, ex.InnerException));
                throw;
            }
            catch (Exception ex) when (ExceptionTypes.IsDbException(ex))
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
            catch (Exception ex) when (ExceptionTypes.IsSqlException(ex))
            {
                ex.SetMessage(DbExceptionMessages.FailedToDelete(InstanceName, id, ex.InnerException));
                throw;
            }
            catch (Exception ex) when (ExceptionTypes.IsDbException(ex))
            {
                ex.SetMessage(DbExceptionMessages.UnexpectedFailure(ex));
                throw;
            }
        }
    }
}