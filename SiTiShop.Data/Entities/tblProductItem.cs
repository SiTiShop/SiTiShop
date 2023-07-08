using System;
using System.Collections.Generic;

namespace SiTiShop.Data.Entities
{
    public partial class TblProductItem
    {
        public TblProductItem()
        {
            TblCartDetails = new HashSet<TblCartDetail>();
            TblOrderDetails = new HashSet<TblOrderDetail>();
        }

        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; } = null!;
        public Guid SizeId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; } = null!;
        public DateTime? UpdateDate { get; set; }

        public virtual TblProduct Product { get; set; } = null!;
        public virtual TblSize Size { get; set; } = null!;
        public virtual ICollection<TblCartDetail> TblCartDetails { get; set; }
        public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; }
    }
}
