using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TuneaPianoPSP.Models;

namespace TuneaPianoPSP.API
{
    public static class GenresAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("api/createGenres", (TuneaPianoDbContext db, Genre genre) =>
            {
                db.Genres.Add(genre);
                db.SaveChanges();
                return Results.Created($"/api/createArtist/{genre.id}", genre);
            });

            app.MapDelete("api/deleteGenre/{id}", (TuneaPianoDbContext db, int id) =>
            {
                Genre genre = db.Genres.SingleOrDefault(genre => genre.id == id);
                if (genre == null)
                {
                    return Results.NotFound();
                }
                db.Genres.Remove(genre);
                db.SaveChanges();
                return Results.NoContent();
            });

            app.MapPut("api/updateGenre/{id}", (TuneaPianoDbContext db, int id, Genre genre) =>
            {
                Genre updateGenre = db.Genres.SingleOrDefault(genre => genre.id == id);
                if (updateGenre == null)
                {
                    return Results.NotFound();
                }
                updateGenre.description = genre.description;


                db.SaveChanges();
                return Results.NoContent();
            });

            app.MapGet("api/genres/{id}", (TuneaPianoDbContext db, int id) =>
            {
                var genreDetails = db.Genres
                .Include(genre => genre.Songs)
                .FirstOrDefault(genre => genre.id == id);

                if (genreDetails == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(genreDetails);
            });
        }
    }
}

