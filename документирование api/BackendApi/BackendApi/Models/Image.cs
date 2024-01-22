using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class Image
    {
        public Image()
        {
            BlockTypes = new HashSet<BlockType>();
        }

        public int ImageId { get; set; }
        public int? BlockId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string? Note { get; set; }

        public virtual Block? Block { get; set; }
        public virtual ICollection<BlockType> BlockTypes { get; set; }
    }
}
