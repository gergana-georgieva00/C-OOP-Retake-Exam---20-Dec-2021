namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        private Book book;

        [SetUp]
        public void SetUp()
        {
            book = new Book("bookName", "author");
        }

        [Test]
        public void InvalidNameShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => book = new Book("", "author"));
        }
    }
}