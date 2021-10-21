using System;

namespace Blog.Models.Entities
{
    public class Like
    {
        public Guid ID { get; set; }

        public Comment Comment { get; set; }

        public User User { get; set; }
    }
}
