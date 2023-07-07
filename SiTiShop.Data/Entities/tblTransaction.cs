using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiTiShop.Data.Entities
{
    public partial class tblTransaction
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public string? PaymentMethod { get; set; }

        public string? Status { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
