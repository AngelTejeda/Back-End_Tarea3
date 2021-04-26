using Tarea_3.DataAccess;

namespace Tarea_3.Models
{
    public abstract class ProductDTO
    {
        public string Name { get; set; }
        public bool IsDiscontinued { get; set; }

        public abstract Product GetDataBaseProductObject();
        public abstract void ModifyDataBaseProduct(Product dataBaseProduct);
    }
}