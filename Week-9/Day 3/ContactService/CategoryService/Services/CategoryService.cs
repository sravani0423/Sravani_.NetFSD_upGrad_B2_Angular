using CategoryService.Models;
using CategoryService.Repositories;

namespace CategoryService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public List<Category> GetAll() => _repo.GetAll();

        public Category GetById(int id) => _repo.GetById(id);

        public void Add(Category category)
        {
            _repo.Add(category);
            _repo.Save();
        }

        public void Update(int id, Category category)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return;

            existing.CategoryName = category.CategoryName;
            existing.Description = category.Description;

            _repo.Update(existing);
            _repo.Save();
        }

        public void Delete(int id)
        {
            var category = _repo.GetById(id);
            if (category == null) return;

            _repo.Delete(category);
            _repo.Save();
        }
    }
}