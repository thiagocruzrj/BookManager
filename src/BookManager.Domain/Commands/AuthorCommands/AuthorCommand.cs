using BookManager.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManager.Domain.Commands.AuthorCommands
{
    public abstract class BookCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Cpf { get; protected set; }
        public string Name { get; protected set; }
        public DateTime Birthdate { get; protected set; }
    }
}
