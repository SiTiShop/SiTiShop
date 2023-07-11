using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiTiShop.Data.Entities;
using SiTiShop.Data.Models.ResultModel;
using SiTiShop.Data.Repositories.CategoryRepo;
using SiTiShop.Data.Repositories.GenericRepository;

namespace SiTiShop.Data.Repositories.UserRepo
{
    public class UserRepo : Repository<TblUser>, IUserRepo
    {
        //private readonly IMapper _mapper;
        private readonly SiTiShopContext _context;
        public UserRepo(/*IMapper mapper,*/ SiTiShopContext context) : base(context)
        {
            //_mapper = mapper;
            _context = context;
        }
        public async Task<TblUser> GetUser(string UserName)
        {
            return await _context.TblUsers.Where(x => x.Username.Equals(UserName)).FirstOrDefaultAsync();
        }

        public async Task<Guid> GetRoleId(string RoleName)
        {
            var role = await _context.TblRoles.Where(x => x.Name.ToLower().Equals(RoleName.ToLower())).FirstOrDefaultAsync();
            return role.Id;
        }

        public async Task<TblUser> GetUserByEmail(string Email)
        {
            return await _context.TblUsers.Where(x => x.Email.Equals(Email)).FirstOrDefaultAsync();
        }
    }
}