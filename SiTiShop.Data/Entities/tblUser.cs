using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiTiShop.Data.Entities
{
    public partial class tblUser
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = null;

        public string Password { get; set; } = null;

        public string? Fullname { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public Guid RoleId { get; set; }

        public string? Status { get; set; }
    }
}
