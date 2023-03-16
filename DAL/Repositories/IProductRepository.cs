using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IProductRepository
    {
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        void Add(Product product);
        void Delete(Product product);
        int SaveChanges();
    }
}
