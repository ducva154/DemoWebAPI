using DAL.Repositories;
using DTO.Entity;
using DTO.Exceptions;
using DTO.Models.Request;
using DTO.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace BLL.Service.Impl
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetByName(string productName)
        {
            return _productRepository.Get(p => p.Name == productName);
        }

        public IEnumerable<Product> GetListByName(string productName)
        {
            return _productRepository.GetList(p => p.Name == productName);
        }

        public AddProductResponse Add(AddProductRequest request)
        {
            if (request.Name.IsNullOrEmpty())
            {
                throw new BusinessException(StatusCodes.Status400BadRequest, "Product name is empty!");
            }
            Product product = new Product();
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.CategoryId = request.CategoryId;
            try
            {
                _productRepository.Add(product);
            }
            catch (Exception)
            {
                throw new BusinessException(StatusCodes.Status500InternalServerError, "Can not add Product to database!");
            }
            AddProductResponse response = new AddProductResponse();
            response.ProductId = product.ProductId;
            return response;
        }

        public void Remove(int id)
        {
            Product product = _productRepository.GetId(id);
            if (product != null)
            {
                try
                {
                    _productRepository.Remove(product);
                }
                catch (Exception)
                {
                    throw new BusinessException(StatusCodes.Status500InternalServerError, "Can not delete Product from database!");
                }
            }
            else
            {
                throw new BusinessException(StatusCodes.Status400BadRequest, "Product not found!");
            }
            
        }

        public Product GetId(int id)
        {
            Product product = _productRepository.GetId(id);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new BusinessException(StatusCodes.Status400BadRequest, "Product not found!");
            }
        }

        public void Update(int id, UpdateProductRequest request)
        {
            Product product = _productRepository.GetId(id);
            if (product != null)
            {
                if (request.Name != null && request.Name != product.Name)
                {
                    product.Name = request.Name;
                }
                if (request.Description != null && request.Description != product.Description)
                {
                    product.Description = request.Description;
                }
                if (request.Price != product.Price)
                {
                    product.Price = request.Price;
                }
                if (request.CategoryId != product.CategoryId)
                {
                    product.CategoryId = request.CategoryId;
                }
            }
            else
            {
                throw new BusinessException(StatusCodes.Status400BadRequest, "Product not found!");
            }
            try
            {
                _productRepository.Update(product);
            }
            catch (Exception)
            {
                throw new BusinessException(StatusCodes.Status500InternalServerError, "Can not update Product to database!");
            }

        }
    }
}
