using System;

namespace Blog.Models.Common
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedOn { get; set; }

        public Guid CreatedByID { get; set; }

        public DateTime? LastModified { get; set; }

        public Guid? LastModifiedByID { get; set; }
    }
}
