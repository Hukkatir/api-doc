using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class Comment
    {
        public Comment()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int BlockId { get; set; }
        public string TextComment { get; set; } = null!;
        public int CreatedBy { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? ParentCommentId { get; set; }

        public virtual Block? Block { get; set; } = null!;
        public virtual User? User { get; set; } = null!;
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
