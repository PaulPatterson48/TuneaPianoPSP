using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TuneaPianoPSP.Models;

namespace TuneaPianoPSP.API
{
	public static class SongsAPI
	{

        public static void Map(WebApplication app)
        {
            app.MapPost("api/createSong", (TuneaPianoDbContext db, Song song) =>
            {
                db.Songs.Add(song);
                db.SaveChanges();
                return Results.Created($"/api/createSong/{song.id}", song);
            });

            app.MapDelete("api/deleteSong/{id}", (TuneaPianoDbContext db, int id) =>
            {
                Song song = db.Songs.SingleOrDefault(song => song.id == id);
                if (song == null)
                {
                    return Results.NotFound();
                }
                db.Songs.Remove(song);
                db.SaveChanges();
                return Results.NoContent();
            });

            app.MapPut("api/updateSong/{id}", (TuneaPianoDbContext db, int id, Song song) =>
            {
                Song updateSong = db.Songs.SingleOrDefault(song => song.id == id);
                if (updateSong == null)
                {
                    return Results.NotFound();
                }
                updateSong.title = song.title;
                updateSong.artistId = song.artistId;
                updateSong.album = song.album;
                updateSong.length = song.length;

                db.SaveChanges();
                return Results.NoContent();
            });

            app.MapGet("api/songs", (TuneaPianoDbContext db) =>
            {
                return db.Songs.ToList();
            });

            app.MapGet("api/songs/{id}", (TuneaPianoDbContext db, int id) =>
            {
                var songDetails = db.Songs
                .Include(song => song.Artist) // Include artist details
                .Include(song => song.Genres) // Include associated genres
                .FirstOrDefault(song => song.id == id);

                if (songDetails == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(songDetails);
            });

        }
    }
}

