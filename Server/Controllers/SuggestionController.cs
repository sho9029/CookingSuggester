﻿using CookingSuggester.Shared;
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
        return await _context.cookings.ToArrayAsync();
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<Cooking>> Get(int id)
    {
        return await _context.cookings.SingleAsync(i => i.Id == id);
    }

    [HttpPost("exclude")]
    public async Task<ActionResult<IEnumerable<Cooking>>> Post([FromBody] string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            return await _context.cookings.ToArrayAsync();
        }

        var ids = query.Split(',').Select(i => int.Parse(i));
        return await _context.cookings
            .Where(i => !ids.Contains(i.Id)).ToArrayAsync();
    }
}
