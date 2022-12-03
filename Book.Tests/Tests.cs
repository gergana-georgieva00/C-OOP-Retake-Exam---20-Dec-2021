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

        [Test]
        public void BookNameGetterWorks()
        {
            Assert.That(book.BookName, Is.EqualTo("bookName"));
        }

        [Test]
        public void AuthorGetterWorks()
        {
            Assert.That(book.Author, Is.EqualTo("author"));
        }

        [Test]
        public void InvalidAuthorShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => book = new Book("bookName", ""));
        }

        [Test]
        public void FootnoteCountGetterWorks()
        {
            Assert.That(book.FootnoteCount, Is.EqualTo(0));
        }

        [Test]
        public void AddFootnoteWithExistentKeyShouldThrow()
        {
            book.AddFootnote(123, "text");
            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(123, "txt"));
        }

        [Test]
        public void FindFootnoteWithNonExistentKeyShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(123));
        }

        [Test]
        public void FindFootnoteWorks()
        {
            book.AddFootnote(123, "text");
            string result = book.FindFootnote(123);
            Assert.That(result, Is.EqualTo($"Footnote #123: text"));
        }

        [Test]
        public void AlterFootnoteWithNonExistentKeyShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(123, "new"));
        }

        [Test]
        public void AlterFootnoteWorks()
        {
            book.AddFootnote(123, "text");
            book.AlterFootnote(123, "new");
            Assert.That(book.FindFootnote(123).Split()[2], Is.EqualTo("new"));
        }
    }
}