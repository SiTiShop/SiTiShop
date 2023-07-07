using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiTiShop.Data.Entities
{
    public partial class tblImage
    {
        public Guid Id { get; set; }

        public string? ImgageUrl { get; set; }

        public Guid? CategoryId { get; set; }

        public Guid? ProductId { get; set; }

        public Guid? UserId { get; set;}
    }
}
