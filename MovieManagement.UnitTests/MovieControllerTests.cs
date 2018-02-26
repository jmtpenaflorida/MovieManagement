using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Controllers;
using MovieManagement.Models;
using MovieManagement.Repositories;
using MovieManagement.Services;
using NUnit.Framework;

namespace MovieManagement.UnitTests
{
    [TestFixture]
    public class MovieControllerTests
    {
        private DbContextOptions<MovieDBContext> options;

        [SetUp]
        public void Setup()
        {
            var builder = new DbContextOptionsBuilder<MovieDBContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            options = builder.Options;
        }

        [Test()]
        public void TestCreateMovieController()
        {
            var controller = new MovieController(new MovieService(new MovieRepository(options)));

            Assert.IsNotNull(controller);
        }

        [Test]
        public void TestAddMovieInController()
        {
            var controller = new MovieController(new MovieService(new MovieRepository(options)));

            var movie = new Movie() { Id = 1, Title = "Star Wars", Rating = "PG", YearReleased = 1977 };

            controller.AddMovie(movie);

            var actual = controller.GetAllMovies().First();

            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Id);
            Assert.AreEqual("Star Wars", actual.Title);
            Assert.AreEqual("PG", actual.Rating);
            Assert.AreEqual(1977, actual.YearReleased);
        }

        [Test]
        public void TestAddTwoMoviesInControllerThenGet()
        {
            var controller = new MovieController(new MovieService(new MovieRepository(options)));

            controller.AddMovie(new Movie() { Id = 1, Title = "Star Wars", Rating = "PG", YearReleased = 1977 });
            controller.AddMovie(new Movie() { Id = 2, Title = "Empire Strikes Back", Rating = "PG", YearReleased = 1980 });

            var actual = controller.GetAllMovies().Count();

            Assert.AreEqual(2, actual);
        }

        [Test]
        public void TestDeleteMovieInController()
        {
            var controller = new MovieController(new MovieService(new MovieRepository(options)));

            controller.AddMovie(new Movie() { Id = 1, Title = "Star Wars", Rating = "PG", YearReleased = 1977 });
            controller.AddMovie(new Movie() { Id = 2, Title = "Empire Strikes Back", Rating = "PG", YearReleased = 1980 });

            controller.DeleteMovie(2);

            Assert.AreEqual(1, controller.GetAllMovies().Count());
        }
    }
}

