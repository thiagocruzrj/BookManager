using BookManager.Core.DomainObjects;
using BookManager.Core.DomainObjects.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace BookManager.Author.Domain.Tests
{
    public class AuthorTest
    {
        [Fact]
        public void Author_Validate_ValidadeMustBeReturnExceptions()
        {
            var ex = Assert.Throws<DomainException>(() =>
            new Author(new Document("142"), "Name", DateTime.Now)
            );

            Assert.Equal("CPF is not valid.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
            new Author(new Document("424.327.860-17"), string.Empty, DateTime.Now)
            );

            Assert.Equal("The field Name must be filled.", ex.Message);
        }
    }
}
