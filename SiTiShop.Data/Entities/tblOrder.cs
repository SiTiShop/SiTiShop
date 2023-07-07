using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiTiShop.Data.Entities
{
    public partial class tblOrder
    {
        public Guid Id { get; set; }

        public Guid? UserId { get; set; }

        public double? TotalPrice { get; set; }

        public int? PointUsed { get; set; }

        public int? PointGain { get; set; }

        public Guid? PlaceId { get; set; }
        
        public string? Descriptiton { get; set; }

        public string? Status { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
