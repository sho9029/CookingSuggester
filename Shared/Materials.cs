using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingSuggester.Shared;

public class Materials
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("materials")]
    public string MaterialList { get; set; }
}
