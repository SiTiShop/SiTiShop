using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiTiShop.Data.Entities;
using SiTiShop.Data.Repositories.GenericRepository;

namespace SiTiShop.Data.Repositories.CategoryRepo
{
    public class CategoryRepo : Repository<TblCategory>, ICategoryRepo
    {
        //private readonly IMapper _mapper;
        private readonly SiTiShopContext _context;
        public CategoryRepo(/*IMapper mapper,*/ SiTiShopContext context) : base(context)
        {
            //_mapper = mapper;
            _context = context;
        }

        public async Task<TblCategory> GetByCategoryName(string name)
        {
            return await _context.TblCategories.Where(x => x.Name.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<List<TblCategory>> GetAllCategory()
        {
            return await _context.TblCategories.ToListAsync();
        }
    }

}
