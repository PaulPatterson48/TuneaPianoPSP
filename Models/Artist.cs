using System;
using System.ComponentModel.DataAnnotations;

namespace TuneaPianoPSP.Models;

public class Artist
{
    public int id { get; set; }
    [Required]
    public string? name { get; set; }
    public int age { get; set; }
    public string? bio { get; set; }


    public ICollection<Song>? Songs { get; set; }
}


