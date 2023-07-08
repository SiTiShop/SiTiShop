using System;
using System.Collections.Generic;

namespace SiTiShop.Business.Entities
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblProducts = new HashSet<TblProduct>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<TblProduct> TblProducts { get; set; }
    }
}
