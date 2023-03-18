using Azure.Core;
using BLL.Service;
using DTO.Entity;
using DTO.Exceptions;
using DTO.Constants;
using DTO.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        public IActionResult GetAll()
        {
            return StatusCode(StatusCodes.Status200OK, _productService.GetAll());
        }

        [HttpGet("product/{name}")]
        public IActionResult GetByName(string name)
        {
            return StatusCode(StatusCodes.Status200OK, _productService.GetByName(name));
        }

        [HttpGet("products/{name}")]
        public IActionResult GetListByName(string name)
        {
            return StatusCode(StatusCodes.Status200OK, _productService.GetListByName(name));
        }

        [HttpGet("product/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _productService.GetId(id));
            }
            catch (BusinessException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
        }

        [HttpPost("product")]
        public IActionResult Add([FromBody] AddProductRequest request)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, _productService.Add(request));
            }
            catch (BusinessException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
        }

        [HttpPut("product/{id}")]
        public IActionResult Update(int id, [FromBody] UpdateProductRequest request)
        {
            try
            {
                _productService.Update(id, request);
                return StatusCode(StatusCodes.Status200OK, ResponseMessageConstant.UPDATE_SUCCESS);
            }
            catch (BusinessException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
        }

        [HttpDelete("product/{id}")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                _productService.Remove(id);
                return StatusCode(StatusCodes.Status200OK, ResponseMessageConstant.DELETE_SUCCESS);
            }
            catch (BusinessException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
        }
    }
}
