using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiTiShop.Business.Service.CategoryService;
using SiTiShop.Data.Entities;

namespace SiTiShop.API.Controllers
{
    [Route("category/")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }


        // GET: Categories/Details/5
        [HttpGet("get-category-by-id")]
        public async Task<IActionResult> Details(Guid id)
        {
            Data.Models.ResultModel.ResultModel result = await _service.getDetail(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpPost("create-category")]
        /*public async Task<IActionResult> Create(string name, string status, string des)
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
        }*/
        public async Task<IActionResult> Create(string name, string status, string des)
        {
            Data.Models.ResultModel.ResultModel result = await _service.create(name, status, des);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        /*[HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {   
            var result = await _context.TblCategories.ToListAsync();

            return Ok(result);
        }*/
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            Data.Models.ResultModel.ResultModel result = await _service.getAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


    }
}
