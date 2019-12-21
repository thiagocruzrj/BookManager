using System;
using System.Collections.Generic;
using System.Text;

namespace BookManager.Book.Domain
{
    public class Book
    {
        public string Title { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public Guid ISBN { get; private set; }
        public Author MyProperty { get; private set; }
    }
}
