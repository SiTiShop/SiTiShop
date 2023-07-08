using System;
using System.Collections.Generic;

namespace SiTiShop.Business.Entities
{
    public partial class TblSize
    {
        public TblSize()
        {
            TblProductItems = new HashSet<TblProductItem>();
        }

        public Guid Id { get; set; }
        public int Name { get; set; }
        public string Status { get; set; } = null!;

        public virtual ICollection<TblProductItem> TblProductItems { get; set; }
    }
}
