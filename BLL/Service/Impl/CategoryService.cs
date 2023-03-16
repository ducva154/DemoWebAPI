using DAL.Repositories;
using DTO.Entity;

namespace BLL.Service.Impl
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        //public CategoryService(ICategoryRepository categoryRepository)
        //{
        //    _categoryRepository = categoryRepository;
        //}
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Category GetById(int id)
        {
            return _unitOfWork.CategoryRepository.GetById(id);
        }
    }
}
