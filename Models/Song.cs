using System;
using System.Collections.Generic;
using TuneaPianoPSP.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Song
{
    public int id { get; set; }
    [Required]
    public string? title { get; set; }
    [ForeignKey("Artists")]
    public int artistId { get; set; }
    public string? album { get; set; }
    public decimal? length { get; set; } = 0.00M;
    public Artist? Artists { get; set; }

    public ICollection<Genre>? Genres { get; set; }

}

