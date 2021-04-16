using Tarea_3.DataAccess;

namespace Tarea_3.Models
{
    public abstract class ProductDTO
    {
        public abstract Product GetDataBaseProductObject();
        public abstract void ModifyDataBaseProduct(Product dataBaseProduct);
    }
}