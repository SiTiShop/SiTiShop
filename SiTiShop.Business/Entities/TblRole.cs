using System;
using System.Collections.Generic;

namespace SiTiShop.Business.Entities
{
    public partial class TblRole
    {
        public TblRole()
        {
            TblUsers = new HashSet<TblUser>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
