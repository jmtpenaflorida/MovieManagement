using System;
using System.Collections.Generic;
using MovieManagement.Models;
using MovieManagement.Repositories;

namespace MovieManagement.Services
{
    public class MovieService : IMovieService
    {
        private IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Movie> Get()
        {
            return _repository.Get();
        }

        public int Add(Movie movie)
        {
            return _repository.Add(movie);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

    }
}
