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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContext _context;
        public CategoryRepository(DbContext context)
        {
            _context = context;
        } 

        public Category GetById(int id)
        {
            return _context.Set<Category>().Find(id);
        }
    }
}
