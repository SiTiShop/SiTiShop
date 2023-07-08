using System;
using System.Collections.Generic;

namespace SiTiShop.Data.Entities
{
    public partial class TblOrderDetail
    {
        public Guid OrderId { get; set; }
        public Guid ProductItemId { get; set; }
        public double PricePerUnit { get; set; }
        public int Quantity { get; set; }

        public virtual TblOrder Order { get; set; } = null!;
        public virtual TblProductItem ProductItem { get; set; } = null!;
    }
}
