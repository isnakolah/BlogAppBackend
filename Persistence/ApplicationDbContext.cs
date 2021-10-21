using Microsoft.EntityFrameworkCore;
using Blog.Models.Entities;
using Blog.Common.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using Blog.Models.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace Blog.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<BlogPostRead> BlogPostReads { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        public DbSet<Sex> Sexes { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedByID = Guid.NewGuid();
                        entry.Entity.CreatedOn = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedByID = Guid.NewGuid();
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasOne(user => user.Author)
                .WithOne(author => author.User)
                .HasForeignKey<Author>(a => a.ID);

            builder
                .Entity<User>()
                .HasOne(user => user.PhoneNumber)
                .WithOne(phoneNo => phoneNo.User)
                .HasForeignKey<PhoneNumber>(ph => ph.ID);

        }
    }
}
