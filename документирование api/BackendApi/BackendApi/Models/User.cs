using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class User
    {
        public User()
        {
            Blocks = new HashSet<Block>();
            Comments = new HashSet<Comment>();
            Feedbacks = new HashSet<Feedback>();
        }

        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int CreatedBy { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Role? Role { get; set; } = null!;
        public virtual ICollection<Block>? Blocks { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<Feedback>? Feedbacks { get; set; }
    }
}
