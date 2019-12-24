using BookManager.Core.DomainObjects;
using Xunit;

namespace BookManager.Domain.Tests
{
    public class CategoryTest
    {
        [Fact]
        public void Category_Validate_ValidadeMustBeReturnExceptions()
        {
            var ex = Assert.Throws<DomainException>(() =>
            new Category(string.Empty, 1)
            );

            Assert.Equal("The field Name must be filled.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
            new Category("Name", 0)
            );

            Assert.Equal("The field Code can't be zero.", ex.Message);
        }
    }
}
