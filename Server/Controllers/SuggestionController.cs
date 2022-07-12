using CookingSuggester.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CookingSuggester.Server.Controllers;

[ApiController]
[Route("[Controller]")]
public class SuggestionController : ControllerBase
{
    private readonly CookingDbContext _context;

    public SuggestionController(CookingDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cooking>>> Get()
    {
        return await _context.cookings.ToListAsync();
    }
}
