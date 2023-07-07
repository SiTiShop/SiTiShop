using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiTiShop.Data.Entities
{
    public partial class tblCart
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string? Status { get; set; }

    }
}
