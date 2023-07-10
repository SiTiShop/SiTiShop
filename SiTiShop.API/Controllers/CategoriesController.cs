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

        [HttpGet("get-by-id")]
        public async Task<IActionResult> Details(Guid id)
        {
            Data.Models.ResultModel.ResultModel result = await _service.getDetail(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(string name, string status, string des)
        {
            Data.Models.ResultModel.ResultModel result = await _service.create(name, status, des);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            Data.Models.ResultModel.ResultModel result = await _service.getAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


    }
}
