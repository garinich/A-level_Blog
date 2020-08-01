using System.Collections.Generic;

namespace BusinessLayer.ModelsBL
{
    public class AuthorBL
    {
        public AuthorBL()
        {
            Articles = new List<ArticleBL>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ArticleBL> Articles { get; set; }
    }
}
