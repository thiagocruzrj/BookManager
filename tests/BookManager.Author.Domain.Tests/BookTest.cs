using BookManager.Core.DomainObjects;
using BookManager.Core.DomainObjects.ValueObjects;
using System;
using Xunit;

namespace BookManager.Catalog.Domain.Tests
{
    public class BookTest
    {
        [Fact]
        public void Book_Validate_ValidadeMustBeReturnExceptions()
        {
            var ex = Assert.Throws<DomainException>(() =>
            new Book(Guid.Empty,Guid.NewGuid(), "Titulo", DateTime.Now, new BookIdentificator("XXX-XX-XXX-XXXX-X"), DateTime.Now)
            );

            Assert.Equal("The CategoryId field can't be empty.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
            new Book(Guid.NewGuid(), Guid.Empty, "Titulo", DateTime.Now, new BookIdentificator("XXX-XX-XXX-XXXX-X"), DateTime.Now)
            );

            Assert.Equal("The AuthorId field can't be empty.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
            new Book(Guid.NewGuid(), Guid.NewGuid(), string.Empty, DateTime.Now, new BookIdentificator("XXX-XX-XXX-XXXX-X"), DateTime.Now)
            );

            Assert.Equal("The field Title must be filled.", ex.Message); 

            ex = Assert.Throws<DomainException>(() =>
            new Book(Guid.NewGuid(), Guid.NewGuid(), "Titulo", DateTime.Now, new BookIdentificator("XXX-XX-XXX-XXXX-"), DateTime.Now)
            );

            Assert.Equal("ISBN is not valid.", ex.Message);
        }
    }
}
