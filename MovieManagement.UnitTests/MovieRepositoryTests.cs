using System;
using System.Linq;
using MovieManagement.Models;
using MovieManagement.Repositories;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;

namespace MovieManagement.UnitTests
{
    [TestFixture()]
    public class MovieRepositoryTests
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
        public void TestCreateMovieRepository()
        {
            var repository = new MovieRepository(options);

            Assert.IsNotNull(repository);
        }

        [Test]
        public void TestAddMovieInRepository()
        {
            var repository = new MovieRepository(options);

            var movie = new Movie() { Id = 1, Title = "Star Wars", Rating = "PG", YearReleased = 1977 };

            repository.Add(movie);

            var actual = repository.Get().First();

            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Id);
            Assert.AreEqual("Star Wars", actual.Title);
            Assert.AreEqual("PG", actual.Rating);
            Assert.AreEqual(1977, actual.YearReleased);
        }

        [Test]
        public void TestAddTwoMoviesInRepositoryThenGet()
        {
            var repository = new MovieRepository(options);

            repository.Add(new Movie() { Id = 1, Title = "Star Wars", Rating = "PG", YearReleased = 1977 });
            repository.Add(new Movie() { Id = 2, Title = "Empire Strikes Back", Rating = "PG", YearReleased = 1980 });

            var actual = repository.Get().Count();

            Assert.AreEqual(2, actual);
        }

        [Test]
        public void TestDeleteMovieInRepository()
        {
            var repository = new MovieRepository(options);

            repository.Add(new Movie() { Id = 1, Title = "Star Wars", Rating = "PG", YearReleased = 1977 });
            repository.Add(new Movie() { Id = 2, Title = "Empire Strikes Back", Rating = "PG", YearReleased = 1980 });

            repository.Delete(2);

            Assert.AreEqual(1, repository.Get().Count());
        }
    }
}
