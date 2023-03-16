using DTO.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Impl
{
    public class ProductRepository : IProductRepository
    {
        protected readonly DbContext _context;
        public ProductRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Add(product);
        }

        public void Delete(Product product)
        {
            _context.Remove(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Set<Product>().ToList();
        }

        public Product GetById(int id)
        {
            return _context.Set<Product>().Find(id);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
