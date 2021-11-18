namespace Blog.Models.Entities;

public class PhoneNumber
{
    public Guid ID { get; set; }

    public string CountryCode { get; set; }

    public string Number { get; set; }

    public Person User { get; set; }
}
