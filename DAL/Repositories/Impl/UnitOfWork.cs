using DAL.Repositories;
using DTO.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_context);
                }
                return _productRepository;
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_context);
                }
                return _categoryRepository;
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
