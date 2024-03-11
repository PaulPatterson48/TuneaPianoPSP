using System;
using Microsoft.EntityFrameworkCore;
using TuneaPianoPSP.Models;

namespace TuneaPianoPSP;

public class TuneaPianoDbContext : DbContext
{
	public DbSet<Artist> Artists { get; set; }
	public DbSet<Genre> Genres { get; set; }
	public DbSet<Song> Songs { get; set; }
	public DbSet<SongGenre> SongGenres { get; set; }

	public TuneaPianoDbContext(DbContextOptions<TuneaPianoDbContext> context) : base(context)
	{

	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.Entity<Artist>().HasData(new Artist[]
		{
			new Artist {id = 1, name = "Big and Rich" , age = 26, bio = "Big & Rich is an American country music duo composed of Big Kenny and John Rich, both of whom are songwriters, vocalists, and guitarists."},
			new Artist {id = 2, name = "Kenny Chesney", age = 55, bio = "Having spent last spring and early summer with his taking-it-to-the-roots I Go Back 2023 Tour of those arenas and markets where he rose to major headlining status, the only country artist to be on Billboard’s Top 10 Touring Artists of the Last 25 Years for the past 14 years is bringing old friends and new to 18 full-scale stadiums with a few more major surprises to come."},
			new Artist {id = 3, name = "Enigma", age = 34, bio = "On December 3, 1990, Enigma released its debut album “MCMXC a.D.”. It was the beginning of an exceptional global success story. A quarter-century later Enigma is launching “Enigma Moments” - an online event to commemorate the project’s 25th anniversary together with you, loyal Enigma fans."},
			new Artist {id = 4, name = "Benny Goodman", age = 77, bio ="Benjamin David Goodman (May 30, 1909 – June 13, 1986) was an American clarinetist and bandleader known as the \"King of Swing\"."}
		});

		modelBuilder.Entity<Genre>().HasData(new Genre[]
		{
			new Genre {id = 1, description = "Country"},
			new Genre {id = 2, description = "Pop"},
			new Genre {id = 3, description = "Jazz"},
			new Genre {id = 4, description = "Blues"},
			new Genre {id = 5, description = "R & B Soul"}
		});

		modelBuilder.Entity<Song>().HasData(new Song[]
		{
			new Song {id = 1, title = "Save a Horse (Ride a Cowboy)", artistId = 0, album = "Horse of a Different Color", length = 180M},
			new Song {id = 2, title = "Take Her Home", artistId = 1, album = "No Shoes nation", length = 183M},
			new Song {id = 3, title = "The Omego Point", artistId = 2, album = "The Fall of a Rebel Angel", length = 339M},
			new Song {id = 4, title = "Sing, Sing, Sing", artistId = 3, album = "The Essential Benny Goodman(Remastered)", length = 540M}

		});

		modelBuilder.Entity<SongGenre>().HasData(new SongGenre[]
		{
			new SongGenre {id = 1, songId = 0, genreId = 0},
			new SongGenre {id = 2, songId = 1, genreId = 0},
			new SongGenre {id = 3, songId = 2, genreId = 1},
			new SongGenre {id = 4, songId = 3, genreId = 2}
		});
    }
}

