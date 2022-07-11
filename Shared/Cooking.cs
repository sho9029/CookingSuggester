﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingSuggester.Shared;

public class Cooking
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    // カンマ区切りで複数個指定
    [Column("material")]
    public string Materials { get; set; }

    // 改行は"\n"を使用
    [Column("process")]
    public string Process { get; set; }
}
