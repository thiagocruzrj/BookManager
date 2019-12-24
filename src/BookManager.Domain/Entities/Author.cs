using BookManager.Core.DomainObjects;
using BookManager.Core.DomainObjects.ValueObjects;
using System;
using System.Collections.Generic;

namespace BookManager.Domain
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
        // EF Relation
        public virtual ICollection<Book> Books { get; private set; } = new HashSet<Book>();

        protected Author() { }

        public void Validate()
        {
            Validations.ValidateIfEmpty(Name, "The field Name must be filled.");
            Validations.ValidateIfAgeIsGreaterThan30(Birthdate, "Management is only done for authors over 30 years old.");
        }
    }
}
