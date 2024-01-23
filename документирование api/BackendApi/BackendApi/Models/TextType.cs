using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class TextType
    {
        public TextType()
        {
            BlockTypes = new HashSet<BlockType>();
        }

        public int TextTypeId { get; set; }
        public int? BlockId { get; set; }
        public string Content { get; set; } = null!;
        public bool? Bold { get; set; }
        public bool? Italic { get; set; }
        public bool? Strikethrough { get; set; }
        public bool? Underline { get; set; }
        public bool? Code { get; set; }
        public string Color { get; set; } = null!;
        public string? Href { get; set; }

        public virtual Block? Block { get; set; }
        public virtual ICollection<BlockType> BlockTypes { get; set; }
    }
}
