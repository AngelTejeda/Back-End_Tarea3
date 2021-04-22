using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Tarea_3.DataAccess;
using Tarea_3.Models;

namespace Tarea_3.BackEnd
{
    public class EmployeeSC : BaseSC
    {
        private readonly string InstanceName = "empleado";

        public IQueryable<Employee> GetAllEmployees()
        {
            return dbContext.Employees.AsQueryable();
        }

        public Employee GetEmployeeById(int id)
        {
            try
            {
                return GetAllEmployees().First(employee => employee.EmployeeId == id);
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

        public void AddNewEmployee(EmployeeDTO newEmployee)
        {
            try
            {
                Employee dataBaseEmployee = newEmployee.GetDataBaseEmployeeObject();

                dbContext.Employees.Add(dataBaseEmployee);
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

        public void UpdateEmployee(int id, EmployeeDTO modifiedEmployee)
        {
            try
            {
                Employee dataBaseEmployee = GetEmployeeById(id);

                modifiedEmployee.ModifyDataBaseEmployee(dataBaseEmployee);

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

        public void DeleteEmployee(int id)
        {
            try
            {
                Employee dataBaseEmployee = GetEmployeeById(id);

                dbContext.Employees.Remove(dataBaseEmployee);

                dbContext.SaveChanges();
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