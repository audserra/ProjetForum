using System;
using System.Collections.Generic;

namespace forum_api.DataAccess.DataObjects
{
    public partial class Topic
    {
        public Topic()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
