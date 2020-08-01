using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class AuthorRepo
    {
        public IList<Author> GetAll()
        {
            using (var ctx = new BlogContext())
            {
                return ctx.Authors
                    .Include(author => author.Articles)
                    .ToList();
            }
        }

        public Author GetById(int id)
        {
            using (var ctx = new BlogContext())
            {
                return ctx.Authors
                    .Include(author => author.Articles)
                    .First(author => author.Id == id);
            }
        }
    }
}
