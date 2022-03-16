using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.Domain
{
    public class Provider : Concept
    {
        // Attributes
        // ==========
        private IList<Product> products = new List<Product>();

        // Properties
        // ==========

        [Key]
        public uint Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        
        [EmailAddress, Required]
        public string Email { get; set; } = string.Empty;

        [DataType(DataType.Password), MinLength(8), Required]
        public string Password { get; set; }

        [Required, NotMapped, DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
        public bool IsApproved { get; set; }
        public DateTime DateCreated { get; set; }
        public IList<Product> Products { get => products; set => products = value; }

        // Methods
        // =======

        // Set IsApproved
        public static void SetIsApproved(Provider provider) => provider.IsApproved = provider.Password == provider.ConfirmPassword;
        public static void SetIsApproved(string password, string confirmPassword, bool isApproved) => isApproved = password == confirmPassword;

        // Login
            // Methods 1 and 2 (expression body form), combined in the "Login" method below:
            //public bool LoginMethod1(string userName, string password) => userName == this.userName && password == this.password;
            //public bool LoginMethod2(string userName, string password, string email) => userName == this.userName && password == this.password && email == this.email;
        public bool Login(string userName, string password, string email = "")
        {
            return !string.IsNullOrEmpty(email)
                ? userName == UserName && password == Password && email == Email
                : userName == UserName && password == Password;
        }

        // Get details
        public override void GetDetails()
        {
            Console.WriteLine(
                $"Id : {Id}\n" +
                $"Nom d'utilisateur : {UserName}\n" +
                $"Email : {Email}\n" +
                $"Mot de passe : {Password}\n" +
                $"Date de création du compte : {DateCreated:ddd dd/MM/yyyy}\n" +
                $"Produits associés : ");
            foreach (Product product in Products)
            { Console.WriteLine($"{product.Name} / "); }
        }

        // Get my products
        public void GetProducts(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "ID":
                    {
                        // Parse string to unsigned integer
                        uint filterValueParsed;
                        while (!uint.TryParse(filterValue.Trim(), out filterValueParsed))
                        {
                            Console.Write("Veuillez saisir un ID valide : ");
                            filterValue = Console.ReadLine();
                        }
                        // Check if value exists in the database
                        bool isAvailableValue = false;
                        foreach (Product product in Products)
                        {
                            if (product.ProductId == filterValueParsed)
                            { isAvailableValue = true; }
                        }
                        if (isAvailableValue == false)
                        { Console.WriteLine("Aucun résultat disponible pour cette recherche."); }
                        // Extract search results
                        foreach (Product product in Products)
                        {
                            if (product.ProductId == filterValueParsed)
                            { Console.WriteLine($"{product.Name}"); }
                        }
                        break;
                    }
                case "Désignation":
                    {
                        // Check if value exists in the database
                        bool isAvailableValue = false;
                        foreach (Product product in Products)
                        {
                            if (product.Name == filterValue)
                            { isAvailableValue = true; }
                        }
                        if (isAvailableValue == false)
                        { Console.WriteLine("Aucun résultat disponible pour cette recherche."); }
                        // Extract search results
                        foreach (Product product in Products)
                        {
                            if (product.Name == filterValue)
                            { Console.WriteLine($"{product.Name}"); }
                        }
                        break;
                    }
                case "Prix":
                    {
                        // Parse string to positive double
                        double filterValueParsed;
                        while (!double.TryParse(filterValue, out filterValueParsed) || double.Parse(filterValue) <= 0)
                        {
                            Console.Write("Veuillez saisir un prix valide : ");
                            filterValue = Console.ReadLine();
                        }
                        // Check if value exists in the database
                        bool isAvailableValue = false;
                        foreach (Product product in Products)
                        {
                            if (product.Price == filterValueParsed)
                            { isAvailableValue = true; }
                        }
                        if (isAvailableValue == false)
                        { Console.WriteLine("Aucun résultat disponible pour cette recherche."); }
                        // Extract search results
                        foreach (Product product in Products)
                        {
                            if (product.Price == filterValueParsed)
                            { Console.WriteLine($"{product.Name}"); }
                        }
                        break;
                    }
                case "Quantité":
                    {
                        // Parse string to unsigned integer
                        uint filterValueParsed;
                        while (!uint.TryParse(filterValue.Trim(), out filterValueParsed))
                        {
                            Console.Write("Veuillez saisir une quantité valide : ");
                            filterValue = Console.ReadLine();
                        }
                        // Check if value exists in the database
                        bool isAvailableValue = false;
                        foreach (Product product in Products)
                        {
                            if (product.Quantity == filterValueParsed)
                            { isAvailableValue = true; }
                        }
                        if (isAvailableValue == false)
                        { Console.WriteLine("Aucun résultat disponible pour cette recherche."); }
                        // Extract search results
                        foreach (Product product in Products)
                        {
                            if (product.Quantity == filterValueParsed)
                            { Console.WriteLine($"{product.Name}"); }
                        }
                        break;
                    }
                case "Date de production":
                    {
                        // Parse string to date
                        DateTime filterValueParsed;
                        while (!DateTime.TryParse(filterValue, out filterValueParsed))
                        {
                            Console.Write("Veuillez saisir une date au format jj/mm/aaaa : ");
                            filterValue = Console.ReadLine();
                        }
                        // Check if value exists in the database
                        bool isAvailableValue = false;
                        foreach (Product product in Products)
                        {
                            if (product.DateProd == filterValueParsed)
                            { isAvailableValue = true; }
                        }
                        if (isAvailableValue == false)
                        { Console.WriteLine("Aucun résultat disponible pour cette recherche."); }
                        // Extract search results
                        foreach (Product product in Products)
                        {
                            if (product.DateProd == filterValueParsed)
                            { Console.WriteLine($"{product.Name}"); }
                        }
                        break;
                    }
            }
        }
        
        // Provider Menu
        public void ProviderMenu()
        {
            // Header Display
            Console.WriteLine(
                $"Utilisateur connecté : {UserName}\n" +
                "\n" +
                "================================================================\n" +
                " Menu Fournisseur                                               \n" +
                "================================================================\n");
            // Choice List
            Console.WriteLine(
                "Faites votre choix :\n" +
                "1- Afficher mes produits\n" +
                "2- Rechercher dans mes produits\n" +
                "3- Afficher mes données personnelles\n" +
                "4- Modifier mon mot de passe\n" +
                "0- Quitter");
            string choice = Console.ReadLine().Trim();
            switch (choice)
            {
                case "1":
                    DisplayProviderProducts();
                    break;
                case "2":
                    FilterProducts();
                    break;
                case "3":
                    DisplayProviderDetails();
                    break;
                case "4":
                    EditPassword();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\n" + "\n" + "\n" + "Choix invalide.\n");
                    ProviderMenu();
                    break;
            }
        }
        // Return to Provider Menu or Quit
        public void ReturnOrQuit()
        {
            Console.WriteLine(
                "\n" +
                "1- Retour au menu principal\n" +
                "0- Quitter");
            string choice = Console.ReadLine().Trim();
            switch (choice)
            {
                case "1":
                    ProviderMenu();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\n" + "\n" + "\n" + "Choix invalide.\n");
                    ReturnOrQuit();
                    break;
            }
        }
        // Display provider's products
        public void DisplayProviderProducts()
        {
            Console.WriteLine(
                $"\n" +
                $"Liste de vos produits\n" +
                $"---------------------");
            foreach (Product product in products)
            {
                product.GetDetails();
                Console.WriteLine("");
            }
            ReturnOrQuit();
        }
        // Filter products
        public void FilterProducts()
        {
            Console.WriteLine(
                $"\n" +
                $"Rechercher un produit\n" +
                $"---------------------");
            Console.WriteLine("Sélectionnez le filtre que vous souhaitez utiliser :\n" +
                "1- ID\n" +
                "2- Désignation\n" +
                "3- Prix\n" +
                "4- Quantité\n" +
                "5- Date de production\n" +
                "0- Revenir au menu précedent");
            string choice = Console.ReadLine().Trim();
            string filterType = string.Empty;
            switch (choice)
            {
                case "1":
                    filterType = "ID";
                    break;
                case "2":
                    filterType = "Désignation";
                    break;
                case "3":
                    filterType = "Prix";
                    break;
                case "4":
                    filterType = "Quantité";
                    break;
                case "5":
                    filterType = "Date de production";
                    break;
                case "0":
                    ReturnOrQuit();
                    break;
                default:
                    Console.WriteLine("\n" + "\n" + "\n" + "Choix invalide.\n");
                    FilterProducts();
                    break;
            }
            Console.Write("Attribuez une valeur à votre filtre : ");
            string filterValue = Console.ReadLine();
            GetProducts(filterType, filterValue);
            ReturnOrQuit();
        }
        // Display provider's details
        public void DisplayProviderDetails()
        {
            Console.WriteLine(
                $"\n" +
                $"Informations personnelles\n" +
                $"-------------------------");
            GetDetails();
            ReturnOrQuit();
        }
        // Edit provider's password
        public void EditPassword()
        {
            Console.WriteLine(
                $"\n" +
                $"Modifier mon mot de passe\n" +
                $"-------------------------");
            
            // Enter old password
            Console.Write("Veuillez saisir votre ancien mot de passe : ");
            string passwordToTest = Console.ReadLine();
            
            // Check if password old is correctly entered
            while (passwordToTest != Password)
            {
                Console.Write("Le mot de passe que vous avez saisi ne correspond pas. Veuillez saisir votre ancien mot de passe : ");
                passwordToTest = Console.ReadLine();
            }

            // Enter new password
            Console.Write("Veuillez saisir votre nouveau mot de passe : ");
            passwordToTest = Console.ReadLine();
            
            // Check if new password's length is regulatory
            while (passwordToTest.Length is < 5 or > 20)
            {
                Console.Write("Le mot de passe doit contenir entre 5 et 20 caractères. Veuillez saisir votre nouveau mot de passe : ");
                passwordToTest = Console.ReadLine();
            }
            // Re-enter new password
            Console.Write("Veuillez ressaisir votre nouveau mot de passe : ");
            var secondPasswordToTest = Console.ReadLine();
            
            // Check if new password is correctly entered
            while (passwordToTest != secondPasswordToTest)
            {
                Console.WriteLine("Les deux saisies ne correspondent pas.");
                EditPassword();
            }

            Password = passwordToTest;
            Console.WriteLine("Mot de passe modifié avec succès.");
            // TEST
            Console.WriteLine($"Votre nouveau mot de passe est {Password}.");
            // TEST FIN
            ReturnOrQuit();
        }
    }
}