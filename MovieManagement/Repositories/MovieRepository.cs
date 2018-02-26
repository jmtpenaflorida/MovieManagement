﻿using System;
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

        int IMovieRepository.Add(Movie movie)
        {
            _repository.Add(movie);
            _repository.SaveChanges();

            return movie.Id;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }

        public IEnumerable<Movie> Get()
        {
            return _repository.Get();
        }
    }
}