using DAL.Repositories;
using DTO.Entity;
using DTO.Models.Request;
using DTO.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public interface IProductService
    {
        Product GetById(int id);
        AddProductResponse Add(AddProductRequest request);
        void Delete(int id);
        void Update(int id, UpdateProductRequest request);
    }
}
