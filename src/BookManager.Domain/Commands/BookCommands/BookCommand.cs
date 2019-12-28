using BookManager.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManager.Domain.Commands.BookCommands
{
    public abstract class BookCommand : Command
    {
        public Guid Id { get; protected set; }
        public Guid CategoryId { get; protected set; }
        public Guid AuthorId { get; protected set; }
        public string Title { get; protected set; }
        public int StockQuantity { get; protected set; }
        public DateTime ReleaseDate { get; protected set; }
        public string Isbn { get; protected set; }
        public DateTime RegisterDate { get; protected set; }
    }
}
