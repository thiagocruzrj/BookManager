using BookManager.Core.DomainObjects;

namespace BookManager.Author.Domain
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

        public override string ToString()
        {
            return $"{Name} - {Code}";
        }

        public void Validate()
        {
            Validations.ValidateIfEmpty(Name, "The field Name must be filled.");
            Validations.EqualsValidate(Code, 0, "The field Code can't be empty.");
        }
    }
}
