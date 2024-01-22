using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class Video
    {
        public Video()
        {
            BlockTypes = new HashSet<BlockType>();
        }

        public int VideoId { get; set; }
        public int? BlockId { get; set; }
        public string VideoUrl { get; set; } = null!;
        public string? Note { get; set; }

        public virtual Block? Block { get; set; }
        public virtual ICollection<BlockType> BlockTypes { get; set; }
    }
}
