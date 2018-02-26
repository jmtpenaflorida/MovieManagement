using System;
using System.Collections.Generic;
using MovieManagement.Models;

namespace MovieManagement.Repository
{
    public interface IRepository
    {
        IEnumerable<Movie> Get();
        int Add(Movie movie);
        void Delete(int id);

    }
}
