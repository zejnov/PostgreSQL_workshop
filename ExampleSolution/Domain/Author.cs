using System;
using System.Collections.Generic;

namespace ExampleSolution.Domain
{
    public class Author
    {
        public long Id { get; set; }
        public string FullName { get; set; }

        public List<Book> Books { get; set; }

    }
}
