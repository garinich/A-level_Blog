using System.Data.Entity;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new CustomInitializer());
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
