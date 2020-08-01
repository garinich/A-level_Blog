using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class ArticleRepo
    {
        public IList<Article> GetAll()
        {
            using (var ctx = new BlogContext())
            {
                return ctx.Articles
                    .Include(article => article.Author)
                    .ToList();
            }
        }

        public Article GetById(int id)
        {
            using (var ctx = new BlogContext())
            {
                return ctx.Articles
                    .Include(article => article.Author)
                    .First(article => article.Id == id);
            }
        }

        public void RemoveById(int id)
        {
            using (var ctx = new BlogContext())
            {
                ctx.Articles.Remove(ctx.Articles.First(article => article.Id == id));
                ctx.SaveChanges();
            }
        }

        public void Add(Article article)
        {
            using (var ctx = new BlogContext())
            {
                article.Author = ctx.Authors.First(author => author.Id == article.Author.Id);
                ctx.Articles.Add(article);
                ctx.SaveChanges();
            }
        }

        public void Edit(Article article)
        {
            using (var ctx = new BlogContext())
            {
                var existingArticle = ctx.Articles
                    .Include(el => el.Author)
                    .FirstOrDefault(el => el.Id == article.Id);

                if (existingArticle == null)
                {
                    ctx.Articles.Add(article);
                }

                else
                {
                    existingArticle.Title = article.Title;
                    existingArticle.Description = article.Description;
                    existingArticle.Content = article.Content;
                    existingArticle.Author = ctx.Authors.FirstOrDefault(el => el.Id == article.Author.Id);

                    ctx.Articles.Attach(existingArticle);
                    ctx.Entry(existingArticle).State = EntityState.Modified;
                }

                ctx.SaveChanges();
            }
        }
    }
}
