using System;
using System.Collections.Generic;

namespace SiTiShop.Data.Entities
{
    public partial class TblCartDetail
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductItemId { get; set; }
        public int Quantity { get; set; }

        public virtual TblCart Cart { get; set; } = null!;
        public virtual TblProductItem ProductItem { get; set; } = null!;
    }
}
