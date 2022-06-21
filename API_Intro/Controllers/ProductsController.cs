using API_Intro.DAL;
using API_Intro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Intro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        //private List<Product> _products = new List<Product>()
        //{
        //    new Product
        //    {
        //        Id = 1,
        //        Name ="IPhone",
        //        Price =1500
        //    },
        //     new Product
        //    {
        //        Id = 2,
        //        Name ="Macbook",
        //        Price =2500
        //    },
        //      new Product
        //    {
        //        Id = 3,
        //        Name ="AirPods",
        //        Price =200
        //    },
        //       new Product
        //    {
        //        Id = 4,
        //        Name ="Apple Watch",
        //        Price =500
        //    },
        //};


        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("get/{id?}")]
        public IActionResult Get(int id)
        {
            Product product = _context.Products.FirstOrDefault(p=>p.Id == id);
            if(product == null) return NotFound(); 
            return Ok(product);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return Ok(products);
        }
        [HttpPost("create")]
        public IActionResult Create(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpPut("create")]
        public IActionResult Update(Product product)
        {
            Product existedproduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if(existedproduct == null) return NotFound();  
            
            existedproduct.Name=product.Name;
            existedproduct.Price=product.Price;

            //_context.Entry(existedproduct).CurrentValues.SetValues(product);

            _context.SaveChanges();
            return Ok(existedproduct);
        }

        [HttpDelete]
       
        public IActionResult Delete(int id)
        {
            Product product=_context.Products.FirstOrDefault(p=>p.Id == id);
            if(product==null) return NotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok(product);
        }
    }
}
