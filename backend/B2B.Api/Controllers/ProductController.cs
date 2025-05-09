using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using B2B.Api.Data;
using B2B.Api.Dtos;

namespace B2B.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] int? storeId, [FromQuery] int? categoryId)
    {
        var query = _context.Products
            .Include(p => p.Category)
            .Include(p => p.Store)
            .AsQueryable();

        if (storeId.HasValue)
            query = query.Where(p => p.StoreId == storeId.Value);

        if (categoryId.HasValue)
            query = query.Where(p => p.CategoryId == categoryId.Value);

        var products = await query
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Brand = p.Brand,
                Sku = p.Sku,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                CategoryName = p.Category.Name,
                StoreName = p.Store.Name
            })
            .ToListAsync();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Store)
            .Where(p => p.Id == id)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Brand = p.Brand,
                Sku = p.Sku,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                CategoryName = p.Category.Name,
                StoreName = p.Store.Name
            })
            .FirstOrDefaultAsync();

        if (product == null)
            return NotFound(
                Problem(
                statusCode: 404,
                title: "Product not found",
                detail: $"Product with ID {id} was not found.",
                instance: HttpContext.Request.Path
            ));

        return Ok(product);
    }
}

