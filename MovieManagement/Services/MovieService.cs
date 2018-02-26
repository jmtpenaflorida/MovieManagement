using System;
using System.Collections.Generic;
using MovieManagement.Models;
using MovieManagement.Repository;

namespace MovieManagement.Services
{
    public class MovieService : IMovieService
    {
        private IRepository _repository;

        public MovieService(IRepository repository)
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
