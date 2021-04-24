using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        // GET: api/<ProductController>
        [HttpGet]
        public IQueryable<Product> Get()
        {
            return new ProductSC().GetAllProducts();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return new ProductSC().GetProductById(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductBasicDataDTO newProduct)
        {
            try
            {
                new ProductSC().AddNewProduct(newProduct);

                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductBasicDataDTO modifiedProduct)
        {
            new ProductSC().UpdateProduct(id, modifiedProduct);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new ProductSC().DeleteProduct(id);
        }
    }
}
