using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using B2B.Api.Data;
using B2B.Api.Dtos;

namespace B2B.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoryController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
    {
        var categories = await _context.Categories
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            })
            .ToListAsync();

        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetCategory(int id)
    {
        var category = await _context.Categories
            .Where(c => c.Id == id)
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            })
            .FirstOrDefaultAsync();

        if (category == null)
            return NotFound(
                Problem(
                statusCode: 404,
                title: "Category not found",
                detail: $"Category with ID {id} was not found.",
                instance: HttpContext.Request.Path
            ));

        return Ok(category);
    }
}