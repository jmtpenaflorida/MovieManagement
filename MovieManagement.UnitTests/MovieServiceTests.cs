using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Models;
using MovieManagement.Repositories;
using MovieManagement.Services;
using NUnit.Framework;

namespace MovieManagement.UnitTests
{
    [TestFixture]
    public class MovieServiceTests
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
        public void TestCreateMovieService()
        {
            var service = new MovieService(new MovieRepository(options));

            Assert.IsNotNull(service);
        }

        [Test]
        public void TestAddMovieInService()
        {
            var service = new MovieService(new MovieRepository(options));

            var movie = new Movie() { Id = 1, Title = "Star Wars", Rating = "PG", YearReleased = 1977 };

            service.Add(movie);

            var actual = service.Get().First();

            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Id);
            Assert.AreEqual("Star Wars", actual.Title);
            Assert.AreEqual("PG", actual.Rating);
            Assert.AreEqual(1977, actual.YearReleased);
        }

        [Test]
        public void TestAddTwoMoviesInServiceThenGet()
        {
            var service = new MovieService(new MovieRepository(options));

            service.Add(new Movie() { Id = 1, Title = "Star Wars", Rating = "PG", YearReleased = 1977 });
            service.Add(new Movie() { Id = 2, Title = "Empire Strikes Back", Rating = "PG", YearReleased = 1980 });

            var actual = service.Get().Count();

            Assert.AreEqual(2, actual);
        }

        [Test]
        public void TestDeleteMovieInService()
        {
            var service = new MovieService(new MovieRepository(options));

            service.Add(new Movie() { Id = 1, Title = "Star Wars", Rating = "PG", YearReleased = 1977 });
            service.Add(new Movie() { Id = 2, Title = "Empire Strikes Back", Rating = "PG", YearReleased = 1980 });

            service.Delete(2);

            Assert.AreEqual(1, service.Get().Count());
        }
    }
}
