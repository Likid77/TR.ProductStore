using System.Linq;
using TR.Domain;
using TR.Service;

namespace TR.Console
{
    class Program7727
    {
        static void Main(string[] args)
        {
            // Manual adding of the providers, products and categories
            Provider PROV1 = new() { Id = 1, UserName = "Magasin Génial", Email = "commercial@mg.tn", Password = "prov1", DateCreated = new DateTime(2021, 12, 27) };
            Provider PROV2 = new() { Id = 2, UserName = "rp", Email = "rp@rp.com", Password = "", DateCreated = new DateTime(2022, 01, 15) };
            Provider PROV3 = new() { Id = 3, UserName = "Hétéroprix", Password = "prov3", DateCreated = new DateTime(2022, 01, 16) };
            Provider PROV4 = new() { Id = 4, UserName = "Firma Market", Password = "prov4", DateCreated = new DateTime(2022, 01, 30) };
            Provider PROV5 = new() { Id = 5, UserName = "Azzouza", Email = "azzouz2002@hotmail.com", Password = "prov5", DateCreated = new DateTime(2022, 02, 16) };
            IList<Provider> providers = new List<Provider>() { PROV1, PROV2, PROV3, PROV4, PROV5 };

            Product PROD1 = new() { ProductId = 1, Name = "Spaghettis", Description = "Pâtes italiennes", Price = 25.5, Quantity = 500, DateProd = new DateTime(2021, 01, 30) };
            Product PROD2 = new() { ProductId = 2, Name = "Chocolat à tartiner", Description = "Teneur en cacao = 40%", Price = 36, Quantity = 250, DateProd = new DateTime(2021, 02, 25) };
            Product PROD3 = new() { ProductId = 3, Name = "Biscuits au céréales", Description = "De simples biscuits", Price = .25, Quantity = 2000, DateProd = new DateTime(2022, 01, 17) };
            Product PROD4 = new() { ProductId = 4, Name = "Détergent", Price = 81, Quantity = 25, DateProd = new DateTime(2022, 01, 30) };
            Product PROD5 = new() { ProductId = 5, Name = "Shampooing", Price = 28, Quantity = 1500, DateProd = new DateTime(2022, 01, 30) };
            Product PROD6 = new() { ProductId = 6, Name = "Déodorant", Price = 39, Quantity = 500, DateProd = new DateTime(2021, 11, 08) };
            IList<Product> products = new List<Product>() { PROD1, PROD2, PROD3, PROD4, PROD5, PROD6 };

            Category CAT1 = new() { CategoryId = 1, Name = "Produits alimentaires" };
            Category CAT2 = new() { CategoryId = 2, Name = "Entretien domestique" };
            Category CAT3 = new() { CategoryId = 3, Name = "Électoménager" };
            IList<Category> categories = new List<Category>() { CAT1, CAT2, CAT3 };

            PROV1.Products = new List<Product>() { PROD1, PROD2, PROD3 };
            PROV2.Products = new List<Product>() { PROD1, PROD5 };
            PROV3.Products = new List<Product>() { PROD1, PROD4 };
            PROV4.Products = new List<Product>() { PROD4, PROD6 };
            PROV5.Products = new List<Product>() { PROD4, PROD6 };

            CAT1.Products = new List<Product>() { PROD1, PROD2 };
            CAT2.Products = new List<Product>() { PROD5 };
            CAT3.Products = new List<Product>() { PROD3, PROD6 };

            // TEST FindProducts, ScanProducts and Filter
            ProductManage productsManage = new() { Products = products };

            System.Console.WriteLine(
                "Méthode FindProducts avec 3 outputs différents :\n" +
                "------------------------------------------------\n" +
                "Standard, Uppercase et Lowercase\n" +
                "--------------------------------");
            foreach (Product product in productsManage.FindProducts(FindProductsStandardOutput, "s"))
            { System.Console.WriteLine(product.Name); }
            System.Console.WriteLine("");

            foreach (Product product in productsManage.FindProducts(FindProductsResultUpperCase, "s"))
            { System.Console.WriteLine(product.Name); }
            System.Console.WriteLine("");

            foreach (Product product in productsManage.FindProducts(FindProductsResultLowerCase, "s"))
            { System.Console.WriteLine(product.Name); }
            System.Console.WriteLine("");
            
            System.Console.WriteLine(
                "Méthode ScanProducts avec 2 outputs différents :\n" +
                "------------------------------------------------\n" +
                "Tous les résultats sur une seule ligne ou un résultat par ligne\n" +
                "---------------------------------------------------------------");
            productsManage.ScanProducts(ScanProductsOneLineDisplay, CAT3);
            productsManage.ScanProducts(ScanProductsMultipleLinesDisplay, CAT3);
            // TEST FIN

            System.Console.WriteLine(
                "Méthode Filter avec 5 types de filtres :\n" +
                "----------------------------------------\n" +
                "ID, Désignation, Prix, Quantité et Date de production\n" +
                "-----------------------------------------------------");
            productsManage.Filter(filterById, "1");
            // Autre manière
                //productsManage.Filter((IList<Product> products, string delFilterValue) =>
                //{
                //    // Parse string to unsigned integer
                //    uint filterValueParsed;
                //    while (!uint.TryParse(delFilterValue.Trim(), out filterValueParsed))
                //    {
                //        System.Console.Write("Veuillez saisir un ID valide : ");
                //        delFilterValue = System.Console.ReadLine();
                //    }
                //    // Check if value exists in the database
                //    bool isAvailableValue = false;
                //    foreach (Product product in products)
                //    {
                //        if (product.ProductId == filterValueParsed)
                //        { isAvailableValue = true; }
                //    }
                //    if (isAvailableValue == false)
                //    { System.Console.WriteLine("Aucun résultat disponible pour cette recherche."); }
                //    // Extract search results
                //    foreach (Product product in products)
                //    {
                //        if (product.ProductId == filterValueParsed)
                //        { System.Console.WriteLine($"{product.Name}"); }
                //    }
                //}, "1");
            productsManage.Filter(filterByDesignation, "Déodorant");
            productsManage.Filter(filterByPrice, "28");
            productsManage.Filter(filterByQuantity, "2000");
            productsManage.Filter(filterByProductionDate, "17/01/2022");
            System.Console.WriteLine("");
            // TEST Displaying providers, products and categories lists
            TestDisplayAllEntitiesListings(providers, products, categories);

            // Enter Credentials
            Provider activeUser = EnterCredentials(providers);

            // Provider Menu (includes: 1 Display provider's products; 2 Filter products; 3 Display provider's details; 4 Edit provider's password)
            activeUser.ProviderMenu();

            // TP 2
            //ProductManage productManage = new ProductManage() { Products = new List<Product>() { PROD1, PROD2, PROD3, PROD4, PROD5, PROD6 } };
            //productManage.FindProducts(Find, "C");
            //productManage.FindProducts((IList<Product> products, string delLettre) =>
            //{
            //    IList<Product> result = new List<Product>();
            //    System.Console.WriteLine("Ay affichage");
            //    return result;
            //}, "S");

            //productManage.UpperName();

            //foreach (Product product in productManage.Products)
            //{
            //    System.Console.WriteLine(product.Name);
            //}
            // TP 2 FIN
        }

        // TEST Displaying providers, products and categories lists
        public static void TestDisplayAllEntitiesListings(IList<Provider> providers, IList<Product> products, IList<Category> categories)
        {
            System.Console.WriteLine(
                "Liste des fournisseurs\n" +
                "----------------------");
            foreach (Provider provider in providers) { System.Console.WriteLine($" PROV{provider.Id} : {provider.UserName}"); }
            System.Console.WriteLine("");

            System.Console.WriteLine(
                "État du stock\n" +
                "-------------");
            foreach (Product product in products) { System.Console.WriteLine($" PROD{product.ProductId} : {product.Name}"); }
            System.Console.WriteLine("");

            System.Console.WriteLine(
                "Liste des catégories\n" +
                "--------------------");
            foreach (Category category in categories) { System.Console.WriteLine($" CAT{category.CategoryId} : {category.Name}"); }

            System.Console.WriteLine("\n");
        }

        // Enter Credentials
        public static Provider EnterCredentials(IList<Provider> providers)
        {
            Provider activeUser = new();

            // Welcome Buddy!
            System.Console.WriteLine(
                "================================================================\n" +
                " Connexion                                                      \n" +
                "================================================================\n");
            
            // Enter username
            System.Console.Write("Nom d'utilisateur : ");
            string userName = System.Console.ReadLine().Trim();
            while (string.IsNullOrEmpty(userName))
            {
                System.Console.Write("Veuillez saisir votre nom d'utilisateur : ");
                userName = System.Console.ReadLine().Trim();
            }
            
            // Check if username exists in the database
            bool isValidUserName = false;
            while (isValidUserName == false)
            {
                foreach (Provider provider in providers)
                {
                    if (provider.UserName == userName)
                    {
                        isValidUserName = true;
                        activeUser = provider;
                    }
                }
                if (isValidUserName == false)
                {
                    System.Console.Write("Nom d'utilisateur inexistant. Veuillez saisir un nom d'utilisateur correct : ");
                    userName = System.Console.ReadLine().Trim();
                }
            }

            // Enter password
            System.Console.Write("Mot de passe : ");
            string password = System.Console.ReadLine();

            // Check if password is correct
            while(password != activeUser.Password)
            {
                System.Console.Write("Le mot de passe saisi est incorrect. Veuillez réessayer : ");
                password = System.Console.ReadLine().Trim();
            }

            return activeUser;
        }

        // FindProducts - 3 types of outputs
            // Type 1: Standard output
        public static IList<Product> FindProductsStandardOutput(IList<Product> products, string delFirstLetter)
        {
            IList<Product> result = new List<Product>();

            foreach (Product product in products)
            {
                if (product.Name.ToLower().StartsWith(delFirstLetter.ToLower()))
                { result.Add(product); }
            }

            return result;
        }
            // Type 2: Result stored in uppercase
        public static IList<Product> FindProductsResultUpperCase(IList<Product> products, string delFirstLetter)
        {
            IList<Product> result = new List<Product>();


            foreach (Product product in products)
            {
                if (product.Name.ToLower().StartsWith(delFirstLetter.ToLower()))
                { result.Add(product); }
            }
            foreach (Product product in result)
            { product.Name = product.Name.ToUpper(); }

            return result;
        }
            // Type 3: Result stored in lowercase
        public static IList<Product> FindProductsResultLowerCase(IList<Product> products, string delFirstLetter)
        {
            IList<Product> result = new List<Product>();

            foreach (Product product in products)
            {
                if (product.Name.ToLower().StartsWith(delFirstLetter.ToLower()))
                { result.Add(product); }
            }
            foreach (Product product in result)
            { product.Name = product.Name.ToLower(); }

            return result;
        }
        // TR Problème: je veux agir sur l’apparence, et non changer la valeur elle-même

        // ScanProducts - 2 types of outputs
            // Type 1: one product per line
        public static void ScanProductsMultipleLinesDisplay(Category delCategory)
        {
            foreach (Product product in delCategory.Products)
            { System.Console.WriteLine(product.Name); }
            System.Console.WriteLine("");
        }
            // Type 2: all products in one line
        public static void ScanProductsOneLineDisplay(Category delCategory)
        {
            foreach (Product product in delCategory.Products)
            { System.Console.Write($"{product.Name}\t"); }
            System.Console.WriteLine("\n");
        }

        // Filter - 5 types: ID, Designation, Price, Quantity and Production Date
            // Type 1: filter by ID
        public static void filterById(IList<Product> products, string delFilterValue)
        {
            // Parse string to unsigned integer
            uint filterValueParsed;
            while (!uint.TryParse(delFilterValue.Trim(), out filterValueParsed))
            {
                System.Console.Write("Veuillez saisir un ID valide : ");
                delFilterValue = System.Console.ReadLine();
            }
            // Check if value exists in the database
            bool isAvailableValue = false;
            foreach (Product product in products)
            {
                if (product.ProductId == filterValueParsed)
                { isAvailableValue = true; }
            }
            if (isAvailableValue == false)
            { System.Console.WriteLine("Aucun résultat disponible pour cette recherche."); }
            // Extract search results
            foreach (Product product in products)
            {
                if (product.ProductId == filterValueParsed)
                { System.Console.WriteLine($"{product.Name}"); }
            }
        }
            // Type 2: filter by designation
        public static void filterByDesignation(IList<Product> products, string delFilterValue)
        {
            // Check if value exists in the database
            bool isAvailableValue = false;
            foreach (Product product in products)
            {
                if (product.Name == delFilterValue)
                { isAvailableValue = true; }
            }
            if (isAvailableValue == false)
            { System.Console.WriteLine("Aucun résultat disponible pour cette recherche."); }
            // Extract search results
            foreach (Product product in products)
            {
                if (product.Name == delFilterValue)
                { System.Console.WriteLine($"{product.Name}"); }
            }
        }
            // Type 3: filter by price
        public static void filterByPrice(IList<Product> products, string delFilterValue)
        {
            // Parse string to positive double
            double filterValueParsed;
            while (!double.TryParse(delFilterValue, out filterValueParsed) || double.Parse(delFilterValue) <= 0)
            {
                System.Console.Write("Veuillez saisir un prix valide : ");
                delFilterValue = System.Console.ReadLine();
            }
            // Check if value exists in the database
            bool isAvailableValue = false;
            foreach (Product product in products)
            {
                if (product.Price == filterValueParsed)
                { isAvailableValue = true; }
            }
            if (isAvailableValue == false)
            { System.Console.WriteLine("Aucun résultat disponible pour cette recherche."); }
            // Extract search results
            foreach (Product product in products)
            {
                if (product.Price == filterValueParsed)
                { System.Console.WriteLine($"{product.Name}"); }
            }
        }
            // Type 4: filter by quantity
        public static void filterByQuantity(IList<Product> products, string delFilterValue)
        {
            // Parse string to unsigned integer
            uint filterValueParsed;
            while (!uint.TryParse(delFilterValue.Trim(), out filterValueParsed))
            {
                System.Console.Write("Veuillez saisir une quantité valide : ");
                delFilterValue = System.Console.ReadLine();
            }
            // Check if value exists in the database
            bool isAvailableValue = false;
            foreach (Product product in products)
            {
                if (product.Quantity == filterValueParsed)
                { isAvailableValue = true; }
            }
            if (isAvailableValue == false)
            { System.Console.WriteLine("Aucun résultat disponible pour cette recherche."); }
            // Extract search results
            foreach (Product product in products)
            {
                if (product.Quantity == filterValueParsed)
                { System.Console.WriteLine($"{product.Name}"); }
            }
        }

            // Type 5: filter by production date
        public static void filterByProductionDate(IList<Product> products, string delFilterValue)
        {
            // Parse string to date
            DateTime filterValueParsed;
            while (!DateTime.TryParse(delFilterValue, out filterValueParsed))
            {
                System.Console.Write("Veuillez saisir une date au format jj/mm/aaaa : ");
                delFilterValue = System.Console.ReadLine();
            }
            // Check if value exists in the database
            bool isAvailableValue = false;
            foreach (Product product in products)
            {
                if (product.DateProd == filterValueParsed)
                { isAvailableValue = true; }
            }
            if (isAvailableValue == false)
            { System.Console.WriteLine("Aucun résultat disponible pour cette recherche."); }
            // Extract search results
            foreach (Product product in products)
            {
                if (product.DateProd == filterValueParsed)
                { System.Console.WriteLine($"{product.Name}"); }
            }
        }
    }
}