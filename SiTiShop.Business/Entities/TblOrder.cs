using System;
using System.Collections.Generic;

namespace SiTiShop.Business.Entities
{
    public partial class TblOrder
    {
        public TblOrder()
        {
            TblTransactions = new HashSet<TblTransaction>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public double TotalPrice { get; set; }
        public int PointUsed { get; set; }
        public int PointGain { get; set; }
        public Guid PlaceId { get; set; }
        public string Description { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime CreateDate { get; set; }

        public virtual TblPlace Place { get; set; } = null!;
        public virtual TblUser User { get; set; } = null!;
        public virtual TblOrderDetail? TblOrderDetail { get; set; }
        public virtual ICollection<TblTransaction> TblTransactions { get; set; }
    }
}
