using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using SiTiShop.Data.Entities;
using SiTiShop.Data.Models.ResultModel;
using SiTiShop.Data.Repositories.CategoryRepo;
using SiTiShop.Data.Repositories.GenericRepository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SiTiShop.Business.Service.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _cateRepo;

        public CategoryService(ICategoryRepo cateRepo)
        {
            _cateRepo = cateRepo;
        }

        public async Task<ResultModel> getDetail(Guid id)
        {
            ResultModel result = new();
            try
            {
                var category = await _cateRepo.Get(id);
                if (category == null)
                {
                    result.IsSuccess = false;
                    result.Code = 400;
                    result.Message = "Khong tim thay danh muc";
                    return result;
                }

                result.IsSuccess = true;
                result.Code = 200;
                result.Data = category;
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

        public async Task<ResultModel> create(string name, string status, string description)
        {
            ResultModel result = new();
            try
            {
                if(name == null || name == "")
                {
                    result.IsSuccess = false;
                    result.Code = 200;
                    result.Message = "Ten danh muc trong!";
                    return result;
                }
                Guid id = Guid.NewGuid();
                TblCategory tblCategory = new TblCategory()
                {
                    Id = id,
                    Name = name,
                    Description = description,
                    Status = status
                };
                var createCategory = await _cateRepo.GetByCategoryName(name);
                if (createCategory != null)
                {
                    result.IsSuccess = false;
                    result.Code = 400;
                    result.Message = "Trung ten danh muc";
                    return result;
                }
                _ = await _cateRepo.Insert(tblCategory);
                result.IsSuccess = true;
                result.Code = 200;
                result.Data = tblCategory;
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

        public async Task<ResultModel> getAll()
        {
            ResultModel result = new();
            try
            {
                var Category = await _cateRepo.GetAllCategory();
                if (Category == null)
                {
                    result.IsSuccess = false;
                    result.Code = 200;
                    result.Message = "Danh muc trong";
                    return result;
                }

                result.IsSuccess = true;
                result.Code = 200;
                result.Data = Category;
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
