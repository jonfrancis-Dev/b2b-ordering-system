using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using B2B.Api.Data;
using B2B.Api.Dtos;

namespace B2B.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly AppDbContext _context;

    public StoreController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StoreDto>>> GetStores()
    {
        var stores = await _context.Stores
            .Select(s => new StoreDto
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                ContactEmail = s.ContactEmail,
                PhoneNumber = s.PhoneNumber
            })
            .ToListAsync();

        return Ok(stores);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<StoreDto>> GetStore(int id)
    {
        var store = await _context.Stores
            .Where(s => s.Id == id)
            .Select(s => new StoreDto
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                ContactEmail = s.ContactEmail,
                PhoneNumber = s.PhoneNumber
            })
            .FirstOrDefaultAsync();

        if (store == null)
           return NotFound(
            Problem(
                statusCode: 404,
                title: "Store not found",
                detail: $"Store with ID {id} was not found.",
                instance: HttpContext.Request.Path
            ));

        return Ok(store);
    }
}
