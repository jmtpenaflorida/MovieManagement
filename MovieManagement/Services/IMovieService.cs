using System;
using System.Collections.Generic;
using MovieManagement.Models;

namespace MovieManagement.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> Get();
        int Add(Movie movie);
        void Delete(int id);
    }
}
