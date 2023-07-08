using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiTiShop.Data.Entities;
using SiTiShop.Data.Repositories.GenericRepository;

namespace SiTiShop.Data.Repositories.CategoryRepo
{
    public interface ICategoryRepo : IRepository<TblCategory>
    {
        Task<TblCategory> GetByCategoryName(string name);
        Task<List<TblCategory>> GetAllCategory();
    }
}
