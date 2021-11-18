using Blog.Models.Common;

namespace Blog.Models.Entities;

public class Author : AuditableEntity
{
    public Guid ID { get; set; }

    public string Alias { get; set; }

    public Person User { get; set; }

    public ICollection<BlogPost> BlogPosts { get; set; }
}
