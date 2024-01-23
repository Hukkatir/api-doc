using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class BlockType
    {
        public int BlockTypeId { get; set; }
        public int? BlockId { get; set; }
        public int? TextTypeId { get; set; }
        public int? VideoId { get; set; }
        public int? ImageId { get; set; }

        public virtual Block? Block { get; set; }
        public virtual Image? Image { get; set; }
        public virtual TextType? TextType { get; set; }
        public virtual Video? Video { get; set; }
    }
}
