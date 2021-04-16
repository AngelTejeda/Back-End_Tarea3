using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Tarea_3.BackEnd;
using Tarea_3.DataAccess;
using Tarea_3.Models;


namespace API_Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductSC productSC = new();

        // GET: api/<ProductController>
        [HttpGet]
        public IQueryable<Product> Get()
        {
            return productSC.GetAllProducts();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return productSC.GetProductById(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] ProductDTO newProduct)
        {
            productSC.AddNewProduct(newProduct);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductDTO modifiedProduct)
        {
            productSC.UpdateProduct(id, modifiedProduct);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productSC.DeleteProduct(id);
        }
    }
}
