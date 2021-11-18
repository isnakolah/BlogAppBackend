using Blog.Models.Common;


namespace Blog.Models.Entities;

public class Comment : AuditableEntity
{
    public Guid ID { get; set; }

    public string Text { get; set; }

    public bool? Blocked { get; set; }

    public BlogPost BlogPost { get; set; }

    public ICollection<Like> Likes { get; set; }

    public Person User { get; set; }
}
