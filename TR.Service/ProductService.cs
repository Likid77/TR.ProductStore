using TR.Data.Infrastructure;
using TR.Domain;
using TR.ServicePattern;

namespace TR.Service
{
    public class ProductService : Service<Product>, IProductService
    {
        //TRContext _context = new TRContext();

        //public void Add(Product product)
        //{
        //    _context.Products.Add(product);
        //    _context.SaveChanges();
        //}

        //public void Remove(Product product)
        //{
        //    _context.Products.Remove(product);
        //    _context.SaveChanges();
        //}

        //public IList<Product> GetAll()
        //{
        //    return _context.Products.ToList();
        //}

        public IList<Product> FindMost5ExpensiveProducts() => GetMany().OrderByDescending(p => p.Price).Take(5).ToList();
        public float UnavailableProductsPercentage() => (float)GetMany().Where(p => p.Quantity == 0).Count() / GetMany().Count();
        public IList<Product>? GetProductsByClient(Client client) { return null; } // Je n'ai pas trouvé comment implémenter ce service
        public void DeleteOldProducts()
        {
            var deleteRequest = GetMany().Where(p => (DateTime.Now - p.DateProd).TotalDays > 365);

            foreach (Product product in deleteRequest) { Delete(product); }
            Commit();
        }
        public void DeleteOldProductsMethod2()
        {
            var deleteRequest = GetMany(p => p.DateProd < DateTime.Now.Subtract(new TimeSpan(365, 0, 0, 0, 0)));
            foreach (Product product in deleteRequest) { Delete(product); }
            Commit();
        }

        public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
