using BookManager.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManager.Domain.Commands.CategoryCommands
{
    public abstract class CategoryCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public int Code { get; protected set; }
    }
}
