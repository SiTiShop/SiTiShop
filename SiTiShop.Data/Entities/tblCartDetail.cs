using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiTiShop.Data.Entities
{
    public partial class tblCartDetail
    {
        public Guid Id { get; set; }

        public Guid CartId { get; set; }

        public Guid ProductItemId { get; set; }

        public int? Quantity { get; set; }

    }
}
