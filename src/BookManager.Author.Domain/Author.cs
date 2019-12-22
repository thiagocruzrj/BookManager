using BookManager.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            Validate();
        }

        public string CPF { get; private set; }
        public string Name { get; private set; }
        public DateTime Birthdate { get; private set; }
        public ICollection<Book> Books { get; private set; }

        public void Validate()
        {
            Validations.ValidateIfEmpty(CPF, "The field Titile must be filled.");
            Validations.ValidateIfEmpty(Name, "The field ISBN must be filled.");
            Validations.ExpressionValidate(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", CPF, "CPF is not valid.");
        }
    }
}
