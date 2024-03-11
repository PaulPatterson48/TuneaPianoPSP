using System;
using System.ComponentModel.DataAnnotations;


namespace TuneaPianoPSP.Models;

public class Song
{
	public int id { get; set; }
	[Required]
	public string? title { get; set; }
	public int? artistId { get; set; }
	public string? album { get; set; }
	public decimal? length { get; set; } = 0.00M;
	public Artist Artist { get; set; }

	public ICollection<Genre> Genres { get; set; }

}

