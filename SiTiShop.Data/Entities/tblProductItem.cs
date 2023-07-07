using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiTiShop.Data.Entities
{
    public partial class tblProductItem
    {
        public Guid Id { get; set; }

        public Guid? ProductId { get; set; }
        
        public string? Name { get; set; }

        public Guid? SizeId { get; set; }

        public int? Price { get; set; }

        public int? Quantity { get; set; }

        public string? Status { get; set; }

        public DateTime UpdateDate { get; set; }

    }
}
