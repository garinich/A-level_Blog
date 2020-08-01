using System.Collections.Generic;
using System.Web.Mvc;

namespace Blog.Models
{
    public class EditArticleViewModel
    {
        public ArticlePL Article { get; set; }
        public SelectList Select { get; set; }
    }
}
