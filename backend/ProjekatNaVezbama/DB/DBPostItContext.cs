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
        //public DbSet<Follower> Followers { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            //User
            mb.Entity<User>(user =>
            {
                user.HasKey(u => u.ID);

            });

            mb.Entity<User>().Property(u => u.Username).IsRequired();
            mb.Entity<User>().Property(u => u.Password).IsRequired();
            mb.Entity<User>().Property(u => u.Email).IsRequired();
            mb.Entity<User>().Property(u => u.ID).UseIdentityColumn();
            mb.Entity<User>().Property(u => u.Username).HasMaxLength(32);
            //Post
            mb.Entity<Post>(p =>
            {
                p.HasKey(post => post.ID);

                p.HasOne(pst => pst.Creator)
                    .WithMany(u => u.Posts)
                    .HasForeignKey(p => p.CreatorID)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Creator_Post_ID");
            });
            mb.Entity<Post>().Property(p => p.CreatorID).IsRequired();
            mb.Entity<Post>().Property(p => p.Content).IsRequired();
            //Comment
            mb.Entity<Comment>(c =>
            {
                c.HasKey(comment => comment.ID);

                c.HasOne(cmt => cmt.Creator)
                    .WithMany(u => u.Comments)
                    .HasForeignKey(c => c.CreatorID)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Creator_Comment_ID");
                c.HasOne(cmt => cmt.OriginPost)
                    .WithMany(p => p.Comments)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Origin_Post");
            });
            //check in here            
            mb.Entity<Comment>().Property(c => c.CreatorID).IsRequired();
            mb.Entity<Comment>().Property(c => c.OriginPostID).IsRequired();
            mb.Entity<Comment>().Property(c => c.Message).IsRequired();

            /*
            mb.Entity<Follower>()
                .HasKey(f => f.ID);

            mb.Entity<Follower>()
                .HasOne(f => f.User)
                .WithMany(u=> u.Following)
                .HasForeignKey(f=> f.ID)
                .OnDelete(DeleteBehavior.NoAction);

            mb.Entity<Follower>()
                .HasMany(f => f.ToFollow)
                .WithMany(u=> u.Followers);*/
            base.OnModelCreating(mb);
        }
    }



}
