using BookManager.Core.DomainObjects;
using System.Collections.Generic;

namespace BookManager.Catalog.Domain
{
    public class Category : Entity
    {
        public Category(string name, int code)
        {
            Name = name;
            Code = code;
            Validate();
        }

        public string Name { get; private set; }
        public int Code { get; private set; }
        // EF Relation
        public virtual ICollection<Book> Books { get; set; }

        protected Category() { }

        public override string ToString()
        {
            return $"{Name} - {Code}";
        }

        public void Validate()
        {
            Validations.ValidateIfEmpty(Name, "The field Name must be filled.");
            Validations.EqualsValidate(Code, 0, "The field Code can't be zero.");
        }
    }
}
