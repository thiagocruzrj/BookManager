using System;
using System.Collections.Generic;
using System.Text;

namespace BookManager.Core.DomainObjects.ValueObjects
{
    public class Document
    {
        public Document(string cpf)
        {
            Cpf = cpf;
            Validations.ExpressionValidate(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", Cpf, "CPF is not valid");
            Validations.ValidateIfEmpty(Cpf, "The field CPF must be filled.");
        }

        public string Cpf { get; private set; }
    }
}
