using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TuneaPianoPSP.Models;

namespace TuneaPianoPSP.API
{
    public static class ArtistAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("api/createArtist", (TuneaPianoDbContext db, Artist artist) =>
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return Results.Created($"/api/createArtist/{artist.id}", artist);
            });

            app.MapDelete("api/deleteArtist/{id}", (TuneaPianoDbContext db, int id) =>
            {
                Artist artist = db.Artists.SingleOrDefault(artist => artist.id == id);
                if (artist == null)
                {
                    return Results.NotFound();
                }
                db.Artists.Remove(artist);
                db.SaveChanges();
                return Results.NoContent();
            });

            app.MapPut("api/updateArtist/{id}", (TuneaPianoDbContext db, int id, Artist artist) =>
            {
                Artist updateArtist = db.Artists.SingleOrDefault(artist => artist.id == id);
                if (updateArtist == null)
                {
                    return Results.NotFound();
                }
                updateArtist.name = artist.name;
                updateArtist.age = artist.age;
                updateArtist.bio = artist.bio;

                db.SaveChanges();
                return Results.NoContent();
            });

            app.MapGet("api/artists", (TuneaPianoDbContext db) =>
            {
                return db.Artists.ToList();
            });

            app.MapGet("api/artist/{id}/details", (TuneaPianoDbContext db, int id) =>
            {
                var artist = db.Artists
                .Include(a => a.Songs)
                .ThenInclude(s => s.Genres)
                .SingleOrDefault(a => a.id == id);

                if (artist == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(artist); ;

            });

        }

    }
}

