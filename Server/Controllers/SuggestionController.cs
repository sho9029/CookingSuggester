using CookingSuggester.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CookingSuggester.Server.Controllers;

[ApiController]
[Route("[Controller]")]
public class SuggestionController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Cooking> Get()
    {
        // データベースから取得
        return Enumerable.Range(1, 5).Select(i => new Cooking
        {
            Id = i,
            Name = $"料理名{i}",
            Materials = "材料1,材料2",
            Process = "手順1\n手順2\n手順3"
        }).ToArray();
    }
}
