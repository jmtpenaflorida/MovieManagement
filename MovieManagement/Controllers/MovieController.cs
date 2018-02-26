using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Models;
using MovieManagement.Services;

namespace MovieManagement.Controllers
{
    public class MovieController : ApiController
    {
        private MovieService _service;

        public MovieController(MovieService service)
        {
            _service = service;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _service.Get();
        }

        public int AddMovie(Movie movie)
        {
            return _service.Add(movie);
        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
           _service.Delete(id);
        }
    }
}
