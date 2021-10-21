using Blog.Models.Common;
using System;
using System.Collections.Generic;

namespace Blog.Models.Entities
{
    public class Author : AuditableEntity
    {
        public Guid ID { get; set; }

        public string Alias { get; set; }

        public User User { get; set; }

        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
