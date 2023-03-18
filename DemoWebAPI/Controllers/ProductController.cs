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

        [HttpGet]
        public IActionResult GetAll()
        {
            return StatusCode(StatusCodes.Status200OK, _productService.GetAll());
        }

        [HttpGet("get-by-name/{productName}")]
        public IActionResult GetByName(string productName)
        {
            return StatusCode(StatusCodes.Status200OK, _productService.GetByName(productName));
        }

        [HttpGet("get-list-by-name/{productName}")]
        public IActionResult GetListByName(string productName)
        {
            return StatusCode(StatusCodes.Status200OK, _productService.GetListByName(productName));
        }

        [HttpGet("get-by-id/{id}")]
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

        [HttpPost]
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

        [HttpPut]
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

        [HttpDelete]
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
