using BookManager.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace BookManager.Author.Domain
{
    public class Author : Entity
    {
        public Author(string cpf, string name, DateTime birthdate, ICollection<Book> books)
        {
            CPF = cpf;
            Name = name;
            Birthdate = birthdate;
            Books = books;
        }

        public string CPF { get; private set; }
        public string Name { get; private set; }
        public DateTime Birthdate { get; private set; }
        public ICollection<Book> Books { get; private set; }
    }

    public class Book : Entity, IAgregateRoot
    {
        public Book(Guid categoryId, Guid authorId, string title, DateTime releaseDate, string isbn)
        {
            CategoryId = categoryId;
            AuthorId = authorId;
            Title = title;
            ReleaseDate = releaseDate;
            ISBN = isbn;
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

        }
    }

    public class Category : Entity
    {
        public Category(string name, int code)
        {
            Name = name;
            Code = code;
        }

        public string Name { get; private set; }
        public int Code { get; private set; }

        public override string ToString()
        {
            return $"{Name} - {Code}";
        }
    }
}
