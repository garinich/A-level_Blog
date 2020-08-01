using System.Collections.Generic;

namespace Blog.Models
{
    public class AuthorPL
    {
        public AuthorPL()
        {
            Articles = new List<ArticlePL>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ArticlePL> Articles { get; set; }
    }
}
