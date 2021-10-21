using System;

namespace Blog.Models.Entities
{
    public class BlogPostRead
    {
        public Guid ID { get; set; }

        public BlogPost Post { get; set; }

        public User User { get; set; }
    }
}