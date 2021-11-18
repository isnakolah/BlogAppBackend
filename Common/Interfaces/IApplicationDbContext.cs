using Blog.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Person> Users { get; set; }

        DbSet<Author> Authors { get; set; }

        DbSet<BlogPost> BlogPosts { get; set; }

        DbSet<Comment> Comments { get; set; }

        DbSet<BlogPostRead> BlogPostReads { get; set; }

        DbSet<Sex> Sexes { get; set; }

        DbSet<Like> Likes { get; set; }

        DbSet<PhoneNumber> PhoneNumbers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
    }
}
