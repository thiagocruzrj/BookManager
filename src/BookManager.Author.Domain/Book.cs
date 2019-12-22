using BookManager.Core.DomainObjects;
using System;

namespace BookManager.Author.Domain
{
    public class Book : Entity, IAgregateRoot
    {
        public Book(Guid categoryId, Guid authorId, string title, DateTime releaseDate, string isbn)
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
        public string ISBN { get; private set; }
        public Category Category { get; private set; }
        public Author Author { get; private set; }
        public void Validate()
        {
            Validations.ValidateIfEmpty(Title, "The field Title must be filled.");
            Validations.ValidateIfEmpty(ISBN, "The field ISBN must be filled.");
            Validations.ExpressionValidate(@"^[A-Z0-9]{3}\-[A-Z0-9]{2}\-[A-Z0-9]{3}\-[A-Z0-9]{4}\-[A-Z0-9]{1}$", ISBN, "ISBN is not valid.");
            Validations.DifferentValidate(CategoryId, Guid.Empty, "The field CategoryId must be filled.");
            Validations.DifferentValidate(AuthorId, Guid.Empty, "The field AuthorId must be filled.");
        }
    }
}
