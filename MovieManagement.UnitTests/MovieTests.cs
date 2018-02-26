using NUnit.Framework;
using System;
using MovieManagement.Models;

namespace MovieManagement.UnitTests
{
    [TestFixture()]
    public class MovieTests
    {
        [Test()]
        public void TestCreateMovie()
        {
            var movie = new Movie() { Id = 1, Title = "Star Wars", Rating = "PG", YearReleased = 1977 };

            Assert.IsNotNull(movie);
            Assert.AreEqual(1, movie.Id);
            Assert.AreEqual("Star Wars", movie.Title);
            Assert.AreEqual("PG", movie.Rating);
            Assert.AreEqual(1977, movie.YearReleased);
        }

        [Test]
        public void TestUpdateMovie()
        {
            var movie = new Movie() { Id = 1, Title = "Star Wars", Rating = "PG", YearReleased = 1977 };

            movie.Id = 2;
            movie.Title = "Empire Strikes Back";
            movie.Rating = "R";
            movie.YearReleased = 1980;

            Assert.IsNotNull(movie);
            Assert.AreEqual(2, movie.Id);
            Assert.AreEqual("Empire Strikes Back", movie.Title);
            Assert.AreEqual("R", movie.Rating);
            Assert.AreEqual(1980, movie.YearReleased);
        }
    }
}
