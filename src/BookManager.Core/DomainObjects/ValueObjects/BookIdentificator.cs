using System;
using System.Collections.Generic;
using System.Text;

namespace BookManager.Core.DomainObjects.ValueObjects
{
    public class BookIdentificator
    {
        public BookIdentificator(string isbn)
        {
            Isbn = isbn;

            Validations.ExpressionValidate(@"^[A-Z0-9]{3}\-[A-Z0-9]{2}\-[A-Z0-9]{3}\-[A-Z0-9]{4}\-[A-Z0-9]{1}$", Isbn, "ISBN is not valid.");
            Validations.ValidateIfEmpty(Isbn, "The field ISBN must be filled.");
        }

        public string Isbn { get; private set; }
    }
}
