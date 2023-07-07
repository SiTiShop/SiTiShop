using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiTiShop.Data.Entities
{
    public partial class tblReward
    {
        public Guid Id { get; set; }

        public Guid? UserId { get; set; }

        public int? Point { get; set; }

        public int? TotalPoint { get; set; }
    }
}
