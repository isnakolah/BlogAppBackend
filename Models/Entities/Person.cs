using Blog.Models.Common;

namespace Blog.Models.Entities;

public class Person : AuditableEntity
{
    public Guid ID { get; set; }

    public string FullName { get; private set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public PhoneNumber PhoneNumber { get; set; }

    public Sex Sex { get; set; }

    public DateTime DateOfBirth { get; set; }

    public Author Author { get; set; }

    public ICollection<Comment> Comments { get; set; }

    public ICollection<Like> Likes { get; set; }

    public ICollection<BlogPostRead> BlogPostReads { get; set; }
}
