using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.Domain;
using TR.Data;
using TR.ServicePattern;

namespace TR.Service
{
    public class CategoryService : ICategoryService
    {
        TRContext _context = new TRContext();

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Remove(Category category)
        {
            _context.Categories.Remove(category);
        }


        public IList<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

    }
}
