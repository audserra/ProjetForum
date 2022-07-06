using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace forum_api.DataAccess.DataObjects
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string User { get; set; } = null!;
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string Content { get; set; } = null!;
        public int TopicId { get; set; }

        [NotMapped]
        public virtual Topic? Topic { get; set; } = null!;
    }
}
