using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Models;

namespace MovieManagement.Controllers
{
    public class MovieController : ApiController
    {
        private DbContextOptions<MovieDBContext> options;

        public MovieController()
        {
            var builder = new DbContextOptionsBuilder<MovieDBContext>();
            builder.UseInMemoryDatabase("MovieDB");
            options = builder.Options;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            using (var db = new MovieDBContext(options))
            {
                return db.Movies.ToList();
            }
        }

        public int AddMovie(Movie movie)
        {
            using (var db = new MovieDBContext(options))
            {
                db.Movies.Add(movie);
                db.SaveChanges();
            }

            return movie.Id;
        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            using (var db = new MovieDBContext(options))
            {
                var movie = db.Movies.FirstOrDefault<Movie>((m) => m.Id == id);

                if (movie != null)
                {
                    db.Movies.Remove(movie);
                    db.SaveChanges();
                }
            }
        }
    }
}
