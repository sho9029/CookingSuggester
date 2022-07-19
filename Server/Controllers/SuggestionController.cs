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
    public async Task<IEnumerable<Cooking>> Get()
    {
        return await _context.cookings.ToArrayAsync();
    }

    [HttpGet("get/{id}")]
    public async Task<Cooking> Get(int id)
    {
        return await _context.cookings.SingleAsync(i => i.Id == id);
    }

    [HttpGet("count")]
    public async Task<int> GetCount()
    {
        return await _context.cookings.CountAsync();
    }

    [HttpPost("exclude")]
    public async Task<Cooking> Post([FromBody] string query = "")
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return await RandomCooking();
        }

        var random = new Random();
        var ids = query.Split(',').Distinct().Select(i => int.Parse(i));
        var exCount = ids.Count();
        var count = await GetCount();
        
        if (count - exCount <= 0)
        {
            throw new ArgumentException();
        }

        var n = random.Next(count - exCount);
        while (ids.Any(i => i == n))
        {
            n++;
        }

        return await _context.cookings.SingleAsync(i => i.Id == n);
    }

    [HttpPost("random")]
    public async Task<Cooking> RandomCooking()
    {
        var random = new Random();
        var n = random.Next(await GetCount());
        return await _context.cookings.SingleAsync(i => i.Id == n);
    }
}
