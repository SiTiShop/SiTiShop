using System;
using System.Collections.Generic;

namespace SiTiShop.Business.Entities
{
    public partial class TblProduct
    {
        public TblProduct()
        {
            TblProductItems = new HashSet<TblProductItem>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public string Status { get; set; } = null!;

        public virtual TblCategory Category { get; set; } = null!;
        public virtual ICollection<TblProductItem> TblProductItems { get; set; }
    }
}
