using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class Category
    {
        public Category()
        {
            Blocks = new HashSet<Block>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string Descrip { get; set; } = null!;
        public int CreatedBy { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Block> Blocks { get; set; }
    }
}
