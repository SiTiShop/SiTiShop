using System;
using System.Collections.Generic;

namespace SiTiShop.Business.Entities
{
    public partial class TblPlace
    {
        public TblPlace()
        {
            TblOrders = new HashSet<TblOrder>();
        }

        public Guid Id { get; set; }
        public int Room { get; set; }
        public string Status { get; set; } = null!;

        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
