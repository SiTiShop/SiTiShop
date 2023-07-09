using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiTiShop.Data.Entities;
using SiTiShop.Data.Repositories.GenericRepository;

namespace SiTiShop.Data.Repositories.UserRepo
{
    public interface IUserRepo : IRepository<TblUser>
    {
        Task<TblUser> GetUser(string UserName);

        Task<TblUser> GetUserByEmail(string Email);

        Task<Guid> GetRoleId(string RoleName);
    }
}
