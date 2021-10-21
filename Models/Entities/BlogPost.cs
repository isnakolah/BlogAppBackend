using Blog.Models.Common;
using Blog.Models.Enums;
using System;
using System.Collections.Generic;

namespace Blog.Models.Entities
{
    public class BlogPost : AuditableEntity
    {
        public Guid ID { get; set; }

        public string Text { get; set; }

        public AgeRestrictions AgeRestrictions { get; set; }

        public Author Author { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
