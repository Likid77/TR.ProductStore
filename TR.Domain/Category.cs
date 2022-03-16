using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.Domain
{
    public class Category : Concept
    {
        // Properties
        // ==========
        public uint CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public IList<Product> Products { get; set; } = new List<Product>();


        // Methods
        // =======
        public override void GetDetails()
        {
            Console.WriteLine(
                $"Id : {CategoryId}\n" +
                $"Désignation : {Name}\n" +
                $"Produits associés : ");
            foreach (Product product in Products)
            {
                Console.WriteLine($"{product.Name} / ");
            }
        }
    }
}
