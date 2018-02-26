using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Models;

namespace MovieManagement.Repository
{
    public class MovieRepository : IRepository
    {
        private DbContextOptions<MovieDBContext> options;

        public MovieRepository()
        {
            var builder = new DbContextOptionsBuilder<MovieDBContext>();
            builder.UseInMemoryDatabase("MovieDB");
            options = builder.Options;
        }

        public int Add(Movie movie)
        {
            using (var db = new MovieDBContext(options))
            {
                db.Movies.Add(movie);
                db.SaveChanges();
            }

            return movie.Id;
        }

        public void Delete(int id)
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

        public IEnumerable<Movie> Get()
        {
            using (var db = new MovieDBContext(options))
            {
                return db.Movies.ToList();
            }
        }
    }
}
