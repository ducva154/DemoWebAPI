using DAL.Repositories;
using DTO.Entity;
using DTO.Models.Request;
using DTO.Models.Response;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BLL.Service.Impl
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public AddProductResponse Add(AddProductRequest request)
        {
            Product product = new Product();
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.CategoryId = request.CategoryId;
            _productRepository.Add(product);
            _productRepository.SaveChanges();
            AddProductResponse response = new AddProductResponse();
            response.ProductId = product.ProductId;
            return response;
        }

        public void Delete(int id)
        {
            Product product = _productRepository.GetById(id);
            if (product != null)
            {
                _productRepository.Delete(product);
                _productRepository.SaveChanges();
            }
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void Update(int id, UpdateProductRequest request)
        {
            Product product = _productRepository.GetById(id);
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
            _productRepository.SaveChanges();
        }
    }
}
