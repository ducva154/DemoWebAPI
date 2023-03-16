using Azure.Core;
using BLL.Service;
using DTO.Entity;
using DTO.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public Category GetProductById(int id)
        {
            return _categoryService.GetById(id);
        }
    }
}
