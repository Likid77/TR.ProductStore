using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.Domain;

namespace TR.Service
{
    public interface ICategoryService
    {
        public void Add(Category category);
        public void Remove(Category category);
        public IList<Category> GetAll();
    }
}
