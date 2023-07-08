using System;
using System.Collections.Generic;

namespace SiTiShop.Data.Entities
{
    public partial class TblTransaction
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string Status { get; set; } = null!;

        public virtual TblOrder Order { get; set; } = null!;
    }
}
