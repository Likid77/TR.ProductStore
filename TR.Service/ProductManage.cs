using TR.Domain;

namespace TR.Service
{
    public delegate IList<Product> FindProductsD(IList<Product> products, string delFirstLetter); // TR Est-ce que je peux remplacer string par char?
    public delegate void ScanProductsD(Category delCategory);
    public delegate void FilterD(IList<Product> products, string delFilterValue);
    // TR Quelle est la différence entre une méthode anonyme et une méthode delegate?

    public class ProductManage
    {
        // Properties
        // ==========
        public IList<Product> Products { get; set; } = new List<Product>();


        // Methods
        // =======
        //Return list of products starting with a given letter
        //public IList<Product> FindProducts(FindProductsD styleOfOutput, string firstLetter)
        //{ return styleOfOutput(Products, firstLetter); }
        public IList<Product> FindProducts(FindProductsD styleOfOutput, string firstLetter) => styleOfOutput(Products, firstLetter);
        //public delegate IList<Product> FindProductsD(IList<Product> products, string delFirstLetter); // TR Est-ce que je peux remplacer string par char?

        // Display list of products for a given category
        //public void ScanProducts(ScanProductsD typeOfDisplay, Category category)
        //{ typeOfDisplay(category); }
        public void ScanProducts(ScanProductsD typeOfDisplay, Category category) => typeOfDisplay(category);
        //public delegate void ScanProductsD(Category delCategory);

        //public static void filterByProductionDate(IList<Product> products, string delFilterValue)

        public void Filter(FilterD typeOfFilter, string filterValue) => typeOfFilter(Products, filterValue);





        //14. Ajouter dans la classe ProductManager les méthodes suivantes :

        // a.Get5Chemical(double price): retourne les cinq premiers produits chimiques qui ont un prix supérieur à price.
        public void Get5Chemical(double price)
        { var query = Products.Where(p => p.Price > price).OrderBy(p => p.Price).Take(5).OfType<Chemical>(); }

        //b.GetProductPrice(double price): retourne les produits qui ont un prix supérieur à price en ignorant les 2 premiers produits.
        public void GetProductPrice(double price)
        { var query = Products.Where(p => p.Price > price).OrderBy(p => p.Price).Skip(2); }

        //c.GetAveragePrice(): retourne le prix moyen de tous les produits
        public void GetAveragePrice()
        { var query = Products.Select(p => p.Price).ToList().Average(); }

        //d.GetMaxPrice(): retourne le produit de max prix.
        public void GetMaxPrice()
        { var query = Products.OrderByDescending(p => p.Price).FirstOrDefault(); }

        // Chemicals List
        public IList<Chemical> GetChemical()
        {
            var query = Products.Where(p => 1 == 1).OfType<Chemical>();
            return (IList<Chemical>)query;
        }

        //e.GetCountProduct(string city): retourne le nombre de produits chemical d’un city.
        public int GetCountProduct(string city)
        {
            IList<Chemical> chemicals = Products.OfType<Chemical>().ToList();
            //return chemicals.Count(c => c.City == city);
            return chemicals.Count(c => c.Address.City == city);
        }

        //f.GetChemicalCity(): retourne la liste des produits chemical ordonnés par city.
        public void GetChemicalCity()
        {
            IList<Chemical> chemicals = Products.OfType<Chemical>().ToList();
            //var query = chemicals.OrderBy(c => c.City);
            var query = chemicals.OrderBy(c => c.Address.City);
        }

        //g.GetChemicalGroupByCity(): retourne la liste des produits chemical ordonnés et groupés par city.
        public void GetChemicalGroupByCity()
        {
            IList<Chemical> chemicals = Products.OfType<Chemical>().ToList();
            //var query = chemicals.OrderBy(c => c.City).OrderBy(c => c.City);
            var query = chemicals.OrderBy(c => c.Address.City).OrderBy(c => c.Address.City);
        }




    }
}
