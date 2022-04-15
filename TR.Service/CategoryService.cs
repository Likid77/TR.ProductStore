using TR.Data.Infrastructure;
using TR.Domain;
using TR.ServicePattern;

namespace TR.Service
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        //TRContext _context = new TRContext();

        //public void Add(Category category)
        //{
        //    _context.Categories.Add(category);
        //    _context.SaveChanges();
        //}

        //public void Remove(Category category)
        //{
        //    _context.Categories.Remove(category);
        //}


        //public IList<Category> GetAll()
        //{
        //    return _context.Categories.ToList();
        //}
        public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
