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
            //kreni odavde
            /*mb.Entity<User>()
                .HasMany(user => user.Posts)
                .WithOne(post => post.Creator)
                //or here
                .HasForeignKey(post => post.CreatorID);*/
            mb.Entity<User>().Property(u => u.Username).IsRequired();
            mb.Entity<User>().Property(u => u.Password).IsRequired();
            mb.Entity<User>().Property(u => u.Email).IsRequired();
            mb.Entity<User>().Property(u => u.ID).UseIdentityColumn();
            mb.Entity<User>().Property(u => u.Username).HasMaxLength(32);

            mb.Entity<Post>(p =>
            {
                p.HasKey(post => post.ID);
            });
            /*mb.Entity<Post>()
                .HasMany(post => post.Comments)
                .WithOne(com => com.OriginalPost);*/
            mb.Entity<Post>()
                .HasOne(post => post.Creator)
                .WithMany(creator => creator.Posts)
                .HasForeignKey(post => post.CreatorID);
            mb.Entity<Post>().Property(p => p.CreatorID).IsRequired();
            mb.Entity<Post>().Property(p => p.Content).IsRequired();

            mb.Entity<Comment>(c =>
            {
                c.HasKey(comment => comment.ID);
            });
            mb.Entity<Comment>()
                .HasOne(comment => comment.OriginalPost)
                .WithMany(post => post.Comments)
                .HasForeignKey(comment => comment.OriginaPostID);
            mb.Entity<Comment>()
                .HasOne(comment => comment.Creator);
            //check in here            
            mb.Entity<Comment>().Property(c => c.CreatorID).IsRequired();
            mb.Entity<Comment>().Property(c => c.Message).IsRequired();

            base.OnModelCreating(mb);
        }
    }



}
