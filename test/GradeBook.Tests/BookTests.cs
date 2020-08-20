using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAStats()
        {
            //arange
            InMemoryBook book = new InMemoryBook("");    

            //act
            var stats = book.GetStats();
            //assert
            Assert.Equal(85.6, stats.Avarage, 1);
            Assert.Equal(90.5, stats.High, 1);
            Assert.Equal(77.3, stats.Low, 1);
            Assert.Equal(56.6, stats.Letter);
        }
        /*
        [Fact]

        public void CheckTheGrades()
        {
            Book book = new Book("NAzar`s");
            book.AddGrade(-1.0);
            Stats res = book.GetStats();
            Assert.Equal(-1 , res.Low);
        }
        */
    }
}