using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.Domain;
using TR.Data;

namespace TR.Service
{
    public class ProductService : IProductService
    {
        TRContext _context = new TRContext();

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public IList<Product> GetAll()
        {
            return _context.Products.ToList();
        }
    }
}
