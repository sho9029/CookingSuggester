using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingSuggester.Shared;

public class Cooking
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("material")]
    public string[] Materials { get; set; }

    [Column("process")]
    public string Process { get; set; }
}
