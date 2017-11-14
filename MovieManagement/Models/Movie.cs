using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace MovieManagement.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearReleased { get; set; }
        public string Rating { get; set; }
    }

    public class MovieDBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options): base(options){}
        public Microsoft.EntityFrameworkCore.DbSet<Movie> Movies { get; set; }
    }
}