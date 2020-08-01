using System.Collections.Generic;

namespace Blog.Models
{
    public class AddArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
    }
}
