using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
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
    }
}
