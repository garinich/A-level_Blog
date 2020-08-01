using System;

namespace BusinessLayer.ModelsBL
{
    public class ArticleBL
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public DateTime DateCreation { get; set; }

        public AuthorBL Author { get; set; }
    }
}
