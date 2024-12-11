using ExampleApi.Models;
using ExampleApi.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        public readonly ExampleApiDbContext context;

        public ProductController(ExampleApiDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await context.Set<Product>().AsNoTracking().ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await context.Set<Product>().AddAsync(product);
            
            await context.SaveChangesAsync();

            return Ok(product);
        }
    }
}   