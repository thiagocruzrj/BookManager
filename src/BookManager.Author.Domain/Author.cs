using BookManager.Core.DomainObjects;
using BookManager.Core.DomainObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BookManager.Author.Domain
{
    public class Author : Entity
    {
        public Author(Document cpf, string name, DateTime birthdate, ICollection<Book> books)
        {
            CPF = cpf;
            Name = name;
            Birthdate = birthdate;
            Books = books;
            Validate();
        }

        public Document CPF { get; private set; }
        public string Name { get; private set; }
        public DateTime Birthdate { get; private set; }
        public ICollection<Book> Books { get; private set; }

        public void Validate()
        {
            Validations.ValidateIfEmpty(Name, "The field ISBN must be filled.");
        }
    }
}
