using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiTiShop.Data.Entities
{
    public partial class tblOrderDetail
    {
        public Guid Id { get; set; }

        public Guid? ProdutcId { get; set; }

        public double? PricePerUnit { get; set; }

        public int? Quantity { get; set; }
    }
}
