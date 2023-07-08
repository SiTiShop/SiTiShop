using System;
using System.Collections.Generic;

namespace SiTiShop.Data.Entities
{
    public partial class TblReward
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Point { get; set; }
        public int TotalPoint { get; set; }

        public virtual TblUser User { get; set; } = null!;
    }
}
