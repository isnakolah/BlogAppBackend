namespace Blog.Models.Entities;

public class Like
{
    public Guid ID { get; set; }

    public Comment Comment { get; set; }

    public Person User { get; set; }
}
