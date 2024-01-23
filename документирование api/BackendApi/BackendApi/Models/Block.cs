using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class Block
    {
        public Block()
        {
            BlockTypes = new HashSet<BlockType>();
            Comments = new HashSet<Comment>();
            Feedbacks = new HashSet<Feedback>();
            Images = new HashSet<Image>();
            TextTypes = new HashSet<TextType>();
            Videos = new HashSet<Video>();
        }

        public int BlockId { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string BlockName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string TextBlock { get; set; } = null!;
        public int IndexBlock { get; set; }
        public int? BlockTypeId { get; set; }
        public int CreatedBy { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? FeedbackId { get; set; }

        public virtual User? Author { get; set; } = null!;
        public virtual Category? Category { get; set; } = null!;
        public virtual Feedback? Feedback { get; set; }
        public virtual ICollection<BlockType> BlockTypes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<TextType> TextTypes { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}
