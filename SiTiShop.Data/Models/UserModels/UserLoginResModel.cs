using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiTiShop.Data.Models.UserModels
{
    public class UserLoginResModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = null!;

        public byte[] Password { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public Guid RoleId { get; set; }

    }

    public class UserByRoleResModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public Guid RoleId { get; set; }

    }
}
