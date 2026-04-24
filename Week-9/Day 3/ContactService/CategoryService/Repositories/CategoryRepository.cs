using CategoryService.Data;
using CategoryService.Models;

namespace CategoryService.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDbContext _context;

        public CategoryRepository(CategoryDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAll() => _context.Categories.ToList();

        public Category GetById(int id) => _context.Categories.Find(id);

        public void Add(Category category) => _context.Categories.Add(category);

        public void Update(Category category) => _context.Categories.Update(category);

        public void Delete(Category category) => _context.Categories.Remove(category);

        public void Save() => _context.SaveChanges();
    }
}