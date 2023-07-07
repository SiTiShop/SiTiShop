using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiTiShop.Data.Entities
{
    public partial class tblCategory
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Status { get; set; }

        public string? Description { get; set; }

    }
}
