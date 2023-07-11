using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiTiShop.Data.Models.ResultModel;

namespace SiTiShop.Business.Service.UserService
{
    public interface IUserService
    {
        public Task<ResultModel> Register(string UserName, string Password, string FullName, string PhoneNumber, string Email);

        public Task<ResultModel> Login(string UserName, string Password);
    }
}
