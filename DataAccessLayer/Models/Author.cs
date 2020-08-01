using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Author
    {
        public Author()
        {
            Articles = new List<Article>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
