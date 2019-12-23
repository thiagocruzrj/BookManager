using BookManager.Core.DomainObjects;
using BookManager.Core.DomainObjects.ValueObjects;
using System;

namespace BookManager.Catalog.Domain
{
    public class Book : Entity, IAggregateRoot
    {
        public Book(Guid categoryId, Guid authorId, string title, DateTime releaseDate, BookIdentificator isbn, DateTime registerDate)
        {
            CategoryId = categoryId;
            AuthorId = authorId;
            Title = title;
            ReleaseDate = releaseDate;
            Isbn = isbn;
            RegisterDate = registerDate;
            Validate();
        }

        public Guid CategoryId { get; private set; }
        public Guid? AuthorId { get; private set; }
        public string Title { get; private set; }
        public int StockQuantity { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public BookIdentificator Isbn { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public Category Category { get; private set; }
        public Author Author { get; private set; }

        public void DebitStock(int amount)
        {
            if (amount < 0) amount *= -1;
            if (!IsThereInStock(amount)) throw new DomainException("Insuficient stock.");
            StockQuantity -= amount;
        }

        public void RestoreStock(int amount)
        {
            StockQuantity += amount;
        }

        public bool IsThereInStock(int amount)
        {
            return StockQuantity >= amount;
        }

        public void Validate()
        {
            Validations.ValidateIfEmpty(Title, "The field Title must be filled.");
            Validations.EqualsValidate(CategoryId, Guid.Empty, "The CategoryId field can't be empty.");
            Validations.EqualsValidate(AuthorId, Guid.Empty, "The AuthorId field can't be empty.");
        }
    }
}
