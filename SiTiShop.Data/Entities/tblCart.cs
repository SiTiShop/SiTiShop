using System;
using System.Collections.Generic;

namespace SiTiShop.Data.Entities
{
    public partial class TblCart
    {
        public TblCart()
        {
            TblCartDetails = new HashSet<TblCartDetail>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Status { get; set; } = null!;

        public virtual TblUser User { get; set; } = null!;
        public virtual ICollection<TblCartDetail> TblCartDetails { get; set; }
    }
}
