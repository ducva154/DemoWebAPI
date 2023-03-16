using DAL.Repositories;
using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        void SaveChanges();
    }
}
