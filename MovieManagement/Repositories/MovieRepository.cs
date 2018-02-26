using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Models;


namespace MovieManagement.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private DbContextOptions<MovieDBContext> options;
        private GenericRepository<Movie> _repository;

        public MovieRepository()
        {
            var builder = new DbContextOptionsBuilder<MovieDBContext>();
            builder.UseInMemoryDatabase("MovieDB");
            options = builder.Options;

            _repository = new GenericRepository<Movie>(new MovieDBContext(options));
        }

        public MovieRepository(DbContextOptions<MovieDBContext> options)
        {
            _repository = new GenericRepository<Movie>(new MovieDBContext(options));
        }

        public int Add(Movie movie)
        {
            _repository.Add(movie);

            return movie.Id;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Movie> Get()
        {
            return _repository.Get();
        }
    }
}
