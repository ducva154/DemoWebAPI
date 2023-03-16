using Azure.Core;
using BLL.Service;
using DTO.Entity;
using DTO.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Product product = _productService.GetById(id);

            return product == null ? StatusCode(StatusCodes.Status400BadRequest) 
                : StatusCode(StatusCodes.Status200OK, product);
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddProductRequest request)
        {
            if (request.Name.IsNullOrEmpty())
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Product name is null");
            }
            return StatusCode(StatusCodes.Status201Created, _productService.Add(request));
        }

        [HttpPut]
        public IActionResult Update(int id, [FromBody] UpdateProductRequest request)
        {
            _productService.Update(id, request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _productService.Delete(id);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
