using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class Feedback
    {
        public Feedback()
        {
            Blocks = new HashSet<Block>();
        }

        public int FeedbackId { get; set; }
        public int UserId { get; set; }
        public int? BlockId { get; set; }
        public int? CommentId { get; set; }
        public bool? Likes { get; set; }
        public int? LikesCount { get; set; }
        public int? DislikesCount { get; set; }

        public virtual Block? Block { get; set; }
        public virtual Comment? Comment { get; set; }
        public virtual User? User { get; set; } = null!;
        public virtual ICollection<Block> Blocks { get; set; }
    }
}
