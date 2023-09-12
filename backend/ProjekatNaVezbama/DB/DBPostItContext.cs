using Microsoft.EntityFrameworkCore;
using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.DB
{
    public class DBPostItContext : DbContext
    {
        public DBPostItContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<User>(user =>
            {
                user.HasKey(u => u.ID);
            });
            base.OnModelCreating(mb);
        }
    }



}
