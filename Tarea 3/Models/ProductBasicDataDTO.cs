using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea_3.DataAccess;

namespace Tarea_3.Models
{
    public class ProductBasicDataDTO : ProductDTO
    {
        public string Nombre { get; set; }
        public bool Descontinuado { get; set; }

        public ProductBasicDataDTO()
        {

        }
        public ProductBasicDataDTO(string name, bool descontinuado)
        {
            Nombre = name;
            Descontinuado = descontinuado;
        }

        public ProductBasicDataDTO(Product product)
        {
            Nombre = product.ProductName;
            Descontinuado = product.Discontinued;
        }

        public override Product GetDataBaseProductObject()
        {
            /*
            return new Product()
            {
                ProductName = Nombre,
                Discontinued = Descontinuado
            };
            */
            Product product = new();

            product.ProductName = Nombre;
            product.Discontinued = Descontinuado;

            return product;
        }

        public override void ModifyDataBaseProduct(Product dataBaseProduct)
        {
            dataBaseProduct.ProductName = Nombre;
            dataBaseProduct.Discontinued = Descontinuado;
        }
    }
}
