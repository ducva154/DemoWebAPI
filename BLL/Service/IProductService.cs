using DAL.Repositories;
using DTO.Entity;
using DTO.Models.Request;
using DTO.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetByName(string productName);
        IEnumerable<Product> GetListByName(string productName);
        Product GetId(int id);
        AddProductResponse Add(AddProductRequest request);
        void Remove(int id);
        void Update(int id, UpdateProductRequest request);
    }
}
