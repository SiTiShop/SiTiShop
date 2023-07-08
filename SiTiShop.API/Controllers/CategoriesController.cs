using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiTiShop.Data.Entities;

namespace SiTiShop.API.Controllers
{
    [Route("category/")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly SiTiShopContext _context;

        public CategoriesController(SiTiShopContext context)
        {
            _context = context;
        }


        // GET: Categories/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.TblCategories == null)
            {
                return NotFound();
            }

            var tblCategory = await _context.TblCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblCategory == null)
            {
                return NotFound();
            }

            return Ok(tblCategory);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(string name, string status, string des)
        {   
            Guid id = Guid.NewGuid();
            TblCategory tblCategory = new TblCategory()
            {
                Id = id,
                Name = name,
                Description = des,
                Status = status
            };
            _context.TblCategories.Add(tblCategory);    
            await _context.SaveChangesAsync();

            return Ok(tblCategory);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {   
            var result = await _context.TblCategories.ToListAsync();

            return Ok(result);
        }




        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status,Description")] TblCategory tblCategory)
        {
            if (ModelState.IsValid)
            {
                tblCategory.Id = Guid.NewGuid();
                _context.Add(tblCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCategory);
        }



        // GET: Categories/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.TblCategories == null)
            {
                return NotFound();
            }

            var tblCategory = await _context.TblCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblCategory == null)
            {
                return NotFound();
            }

            return View(tblCategory);
        }

    }
}
