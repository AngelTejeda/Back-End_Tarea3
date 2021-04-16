using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Tarea_3.DataAccess;
using Tarea_3.Models;

namespace Tarea_3.BackEnd
{
    public class ProductSC : BaseSC
    {
        private readonly string InstanceName = "producto";

        public IQueryable<Product> GetAllProducts()
        {
            return dbContext.Products.AsQueryable();
        }

        public Product GetProductById(int id)
        {
            try
            {
                return GetAllProducts().First(product => product.ProductId == id);
            }
            catch (ArgumentNullException ex)
            {
                ex.SetMessage(DbExceptionMessages.FieldIsRequired("id"));
                throw;
            }
            catch (InvalidOperationException ex)
            {
                ex.SetMessage(DbExceptionMessages.FailedToAdd(InstanceName));
                throw;
            }
        }

        public void AddNewProduct(ProductDTO newProduct)
        {
            try
            {
                Product dataBaseProduct = newProduct.GetDataBaseProductObject();

                dbContext.Products.Add(dataBaseProduct);
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

        public void UpdateProduct(int id, ProductDTO modifiedProduct)
        {
            try
            {
                Product dataBaseProduct = GetProductById(id);

                modifiedProduct.ModifyDataBaseProduct(dataBaseProduct);

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

        public void DeleteProduct(int id)
        {
            try
            {
                Product dataBaseProduct = GetProductById(id);

                dbContext.Products.Remove(dataBaseProduct);

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