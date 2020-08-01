using System;

namespace Blog.Models
{
    public class ArticlePL
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public DateTime DateCreation { get; set; }

        public AuthorPL Author { get; set; }
    }
}
