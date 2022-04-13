using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.Domain;

namespace TR.Service
{
    public interface IProductService
    {
        public void Add(Product product);
        public void Remove(Product product);
        public IList<Product> GetAll();
    }
}
