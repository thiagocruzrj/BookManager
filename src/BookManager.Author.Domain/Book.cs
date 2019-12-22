using BookManager.Core.DomainObjects;
using BookManager.Core.DomainObjects.ValueObjects;
using System;

namespace BookManager.Author.Domain
{
    public class Book : Entity, IAgregateRoot
    {
        public Book(Guid categoryId, Guid authorId, string title, DateTime releaseDate, BookIdentificator isbn)
        {
            CategoryId = categoryId;
            AuthorId = authorId;
            Title = title;
            ReleaseDate = releaseDate;
            ISBN = isbn;
            Validate();
        }

        public Guid CategoryId { get; private set; }
        public Guid AuthorId { get; private set; }
        public string Title { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public BookIdentificator ISBN { get; private set; }
        public Category Category { get; private set; }
        public Author Author { get; private set; }
        public void Validate()
        {
            Validations.ValidateIfEmpty(Title, "The field Title must be filled.");
            Validations.DifferentValidate(CategoryId, Guid.Empty, "The field CategoryId must be filled.");
            Validations.DifferentValidate(AuthorId, Guid.Empty, "The field AuthorId must be filled.");
        }
    }
}
