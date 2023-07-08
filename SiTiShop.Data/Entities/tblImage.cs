using System;
using System.Collections.Generic;

namespace SiTiShop.Data.Entities
{
    public partial class TblImage
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public Guid? CategoryId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? UserId { get; set; }
    }
}
