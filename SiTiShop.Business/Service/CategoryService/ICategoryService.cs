using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiTiShop.Data.Entities;
using SiTiShop.Data.Models.ResultModel;
using SiTiShop.Data.Repositories.GenericRepository;

namespace SiTiShop.Business.Service.CategoryService
{

    public interface ICategoryService 
    {
        public Task<ResultModel> getDetail(Guid id);
    }
}
