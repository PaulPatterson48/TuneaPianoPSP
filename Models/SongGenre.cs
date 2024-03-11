using System;
using System.ComponentModel.DataAnnotations;

namespace TuneaPianoPSP.Models;

public class SongGenre
{
    public int id { get; set; }
    [Required]
    public int songId { get; set; }
    public int genreId { get; set; }

    //public Genre? Genres { get; set; }

}


