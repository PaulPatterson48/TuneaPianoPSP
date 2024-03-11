using System;
using System.ComponentModel.DataAnnotations;

namespace TuneaPianoPSP.Models;

public class Genre
{
    public int id { get; set; }
    [Required]
    public string description { get; set; }

    public ICollection<Song> Songs { get; set; }
}


