using System;
using System.Collections.Generic;

namespace SiTiShop.Data.Entities
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblCarts = new HashSet<TblCart>();
            TblOrders = new HashSet<TblOrder>();
            TblRewards = new HashSet<TblReward>();
        }

        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public byte[] Password { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Guid RoleId { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreateDate { get; set; }

        public virtual TblRole Role { get; set; } = null!;
        public virtual ICollection<TblCart> TblCarts { get; set; }
        public virtual ICollection<TblOrder> TblOrders { get; set; }
        public virtual ICollection<TblReward> TblRewards { get; set; }
    }
}
