using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SiTiShop.Data.Entities;
using SiTiShop.Data.Models.ResultModel;
using SiTiShop.Data.Repositories.CategoryRepo;
using SiTiShop.Data.Repositories.UserRepo;
using SiTiShop.Business.Utilities.UserAuthentication;
using System.Security.Cryptography;

namespace SiTiShop.Business.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<ResultModel> Register(string UserName, string Password, string FullName, string PhoneNumber, string Email)
        {
            ResultModel result = new();
            try
            {
                var getUserRoleId = await _userRepo.GetRoleId("User");
                var checkUserName = await _userRepo.GetUser(UserName);
                if (checkUserName != null)
                {
                    result.IsSuccess = false;
                    result.Code = 400;
                    result.Message = "Trung Username";
                    return result;
                }
                var checkUserEmail = await _userRepo.GetUserByEmail(Email);
                if (checkUserEmail != null)
                {
                    result.IsSuccess = false;
                    result.Code = 400;
                    result.Message = "Trung Email";
                    return result;
                }
                byte[] HashPassword = UserUtilities.CreatePasswordHash(Password);
                Guid id = Guid.NewGuid();
                DateTime Date = DateTime.Now;
                TblUser UserModel = new TblUser()
                {
                    Id = id,
                    Username = UserName,
                    Password = HashPassword,
                    Fullname = FullName,
                    PhoneNumber = PhoneNumber,
                    Email = Email,
                    Status = "Active",
                    RoleId = getUserRoleId,
                    CreateDate = Date,
                };
                _ = await _userRepo.Insert(UserModel);

                result.IsSuccess = true;
                result.Code = 200;
                result.Data = HashPassword;
                return result;

            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Code = 400;
                result.ResponseFailed = e.InnerException != null ? e.InnerException.Message + "\n" + e.StackTrace : e.Message + "\n" + e.StackTrace;
            }
            return result;
        }

        public async Task<ResultModel> Login(string UserName, string Password)
        {
            ResultModel result = new();
            try
            {
                var User = await _userRepo.GetUser(UserName);
                if (User == null)
                {
                    result.IsSuccess = false;
                    result.Code = 400;
                    result.Message = "User khong ton tai";
                    return result;
                }
                byte[] HashPasswordInput = UserUtilities.CreatePasswordHash(Password);
                bool isMatch = UserUtilities.VerifyPasswordHash(HashPasswordInput, User.Password);
                if (!isMatch)
                {
                    result.IsSuccess = false;
                    result.Code = 400;
                    result.Message = "Mat khau sai";
                    return result;
                }

                result.IsSuccess = true;
                result.Code = 200;
                result.Data = User;
                result.Message = "Dang nhap thanh cong";
                return result;

            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Code = 400;
                result.ResponseFailed = e.InnerException != null ? e.InnerException.Message + "\n" + e.StackTrace : e.Message + "\n" + e.StackTrace;
            }
            return result;
        }
    }
}