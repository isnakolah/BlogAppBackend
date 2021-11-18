namespace Blog.Models.Entities;

public class Sex
{
    public Guid ID { get; set; }

    public string Name { get; set; }

    public ICollection<Person> Users { get; set; }
}
