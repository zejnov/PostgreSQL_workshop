using System;

namespace ExampleSolution.Domain
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PrintDate { get; set; }

        public long AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
