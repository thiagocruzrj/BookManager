using BookManager.Core.DomainObjects;
using BookManager.Core.DomainObjects.ValueObjects;
using System;
using Xunit;

namespace BookManager.Author.Domain.Tests
{
    public class AuthorTest
    {
        [Fact]
        public void Author_Validate_ValidadeMustBeReturnExceptions()
        {
            var ex = Assert.Throws<DomainException>(() =>
            new Author(new Document("142"), "Name", new DateTime(1980, 3, 15))
            );

            Assert.Equal("CPF is not valid.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
            new Author(new Document("424.327.860-17"), string.Empty, new DateTime(1980, 3, 15))
            );

            Assert.Equal("The field Name must be filled.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
            new Author(new Document("424.327.860-17"), "Name", new DateTime(1994, 3, 15))
            );

            Assert.Equal("Management is only done for authors over 30 years old.", ex.Message);
        }
    }
}
