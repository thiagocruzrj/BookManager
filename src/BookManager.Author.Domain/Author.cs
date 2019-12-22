using BookManager.Core.DomainObjects;
using BookManager.Core.DomainObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BookManager.Author.Domain
{
    public class Author : Entity
    {
        public Author(Document cpf, string name, DateTime birthdate)
        {
            Cpf = cpf;
            Name = name;
            Birthdate = birthdate;
            Validate();
        }

        public Document Cpf { get; private set; }
        public string Name { get; private set; }
        public DateTime Birthdate { get; private set; }
        public ICollection<Book> Books { get; private set; }

        public void Validate()
        {
            Validations.ValidateIfEmpty(Name, "The field Name must be filled.");
        }
    }
}
