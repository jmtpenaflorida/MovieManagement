using System;
using System.Collections.Generic;
using MovieManagement.Models;

namespace MovieManagement.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Get();
        int Add(Movie movie);
        void Delete(int id);

    }
}
