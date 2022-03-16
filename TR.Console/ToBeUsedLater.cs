using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.Console
{
    internal class ToBeUsedLater
    {
        //public static void DisplayAllEntities(IList<Provider> _providers, IList<Product> _products, IList<Category> _categories)
        //{
        //    // Displaying providers listing
        //    System.Console.WriteLine(
        //        "================================================================\n" +
        //        " Liste des fournisseurs                                         \n" +
        //        "================================================================\n");
        //    foreach (Provider _provider in _providers)
        //    {
        //        System.Console.WriteLine(
        //            $" PROV{_provider.Id} : {_provider.UserName.ToUpper()}\n" +
        //            $"----------------------------------------------------------------");
        //        _provider.GetDetails();
        //        System.Console.WriteLine("\n");
        //    }
        //    // Displaying products listing
        //    System.Console.WriteLine(
        //        "================================================================\n" +
        //        " État du stock                                                  \n" +
        //        "================================================================\n");
        //    foreach (Product _product in _products)
        //    {
        //        System.Console.WriteLine(
        //            $" PROD{_product.ProductId} : {_product.Name.ToUpper()}\n" +
        //            $"----------------------------------------------------------------");
        //        _product.GetDetails();
        //        System.Console.WriteLine("\n");
        //    }
        //    // Displaying categories listing
        //    System.Console.WriteLine(
        //        "================================================================\n" +
        //        " Liste des catégories                                           \n" +
        //        "================================================================\n");
        //    foreach (Category _category in _categories)
        //    {
        //        System.Console.WriteLine(
        //            $" CAT{_category.CategoryId} : {_category.Name.ToUpper()}\n" +
        //            $"----------------------------------------------------------------");
        //        _category.GetDetails();
        //        System.Console.WriteLine("\n");
        //    }
        //}



        //class Program7726
        //{

        //    public static void EnterCredentials(out string _userName, out string _email, out string _password)
        //    {
        //        System.Console.WriteLine(
        //            "-----------------------\n" +
        //            " Connexion Fournisseur \n" +
        //            "-----------------------");

        //        System.Console.WriteLine("Nom d'utilisateur :");
        //        _userName = System.Console.ReadLine().Trim();
        //        while (string.IsNullOrEmpty(_userName))
        //        {
        //            System.Console.WriteLine("Veuillez saisir votre nom d'utilisateur :");
        //            _userName = System.Console.ReadLine().Trim();
        //        }

        //        System.Console.WriteLine("E-mail (facultatif) :");
        //        _email = System.Console.ReadLine().Trim();

        //        System.Console.WriteLine("Mot de passe :");
        //        _password = System.Console.ReadLine();
        //        while (string.IsNullOrEmpty(_password))
        //        {
        //            System.Console.WriteLine("Veuillez saisir votre mot de passe :");
        //            _password = System.Console.ReadLine().Trim();
        //        }

        //        System.Console.WriteLine($"Votre nom d'utilisateur est {_userName}.");
        //        if (!string.IsNullOrEmpty(_email)) { System.Console.WriteLine($"Votre mot e-mail est {_email}."); }
        //        System.Console.WriteLine($"Votre mot de passe est {_password}.");
        //    }

        //    public static void AddProduct(out string _name, out string _description, out double _price, out uint _quantity, out DateTime _dateProd)
        //    {
        //        System.Console.WriteLine(
        //            "----------------\n" +
        //            " Ajout Produits \n" +
        //            "----------------");

        //        System.Console.WriteLine("Désignation du produit :");
        //        _name = System.Console.ReadLine().Trim();
        //        while (string.IsNullOrEmpty(_name))
        //        {
        //            System.Console.WriteLine("Veuillez saisir le nom du produit à ajouter :");
        //            _name = System.Console.ReadLine().Trim();
        //        }

        //        System.Console.WriteLine("Description (facultatif) :");
        //        _description = System.Console.ReadLine().Trim();

        //        System.Console.WriteLine("Prix de vente :");
        //        string _priceStr = System.Console.ReadLine();
        //        while (!double.TryParse(_priceStr, out _price) || double.Parse(_priceStr) <= 0)
        //        {
        //            System.Console.WriteLine("Veuillez saisir un prix de vente valide :");
        //            _priceStr = System.Console.ReadLine();
        //        }
        //        _price = float.Parse(_priceStr);
        //        _price = Math.Round(_price * .9, 3); //Final price with 10% discount

        //        System.Console.WriteLine("Quantité à ajouter au stock :");
        //        string _quantityStr = System.Console.ReadLine();
        //        while (!uint.TryParse(_quantityStr, out _quantity))
        //        {
        //            System.Console.WriteLine("Veuillez saisir une quantité valide :");
        //            _quantityStr = System.Console.ReadLine();
        //        }

        //        System.Console.WriteLine("Date de production (format : jj/mm/aaaa) :");
        //        string _dateProdStr = System.Console.ReadLine();
        //        while (!DateTime.TryParse(_dateProdStr, out _dateProd))
        //        {
        //            System.Console.WriteLine("Veuillez saisir une date au format jj/mm/aaaa :");
        //            _dateProdStr = System.Console.ReadLine();
        //        }

        //        System.Console.WriteLine("Vous avez saisi le produit suivant :");
        //        System.Console.WriteLine($"\tDésignation : {_name}");
        //        if (!string.IsNullOrEmpty(_description)) { System.Console.WriteLine($"\tDescription : {_description}"); }
        //        System.Console.WriteLine($"\tPrix de vente remisé (-10%) : {_price} DT");
        //        System.Console.WriteLine($"\tQuantité à ajouter au stock : {_quantity}");
        //        System.Console.WriteLine($"\tDate de production : {_dateProd:dd/MM/yyyy}");
        //    }

        //    //public static void SetIsApproved(Provider provider)
        //    //{
        //    //    System.Console.WriteLine($"Valider l'accès du fournisseur {provider} ? (O/N)");
        //    //    string _answer = System.Console.ReadLine().Trim().ToUpper();
        //    //    while (_answer is not "N" and not "O")
        //    //    {
        //    //        System.Console.WriteLine("Veuillez taper O pour valider l'accès ou N pour refuser l'accès :");
        //    //        _answer = System.Console.ReadLine().Trim().ToUpper();
        //    //    }
        //    //}



        //    //Main Function
        //    static void Main(string[] args)
        //    {
        //        //Approve access
        //        Provider _provider = new Provider();
        //        _provider.Password = "abcde";
        //        _provider.ConfirmPassword = "abcde";
        //        //Provider.SetIsApproved(_provider);
        //        Provider.SetIsApproved(_provider.Password, _provider.ConfirmPassword, isApproved

        //    //Welcome Screen + Login or Create Account
        //        string _userName;
        //        string _email;
        //        string _password;
        //        EnterCredentials(out _userName, out _email, out _password);

        //        //Validate login

        //        //Add products
        //        string _name;
        //        string _description;
        //        double _price;
        //        uint _quantity;
        //        DateTime _dateProd;
        //        AddProduct(out _name, out _description, out _price, out _quantity, out _dateProd);

        //        //Display stock per product

        //        //Display Products types
        //        Product _simpleProduct = new Product();
        //        Product _biologicalProduct = new Biological();
        //        Product _chemicalProduct = new Chemical();

        //        System.Console.WriteLine(
        //            "----------------------------\n" +
        //            " Types de produits proposés \n" +
        //            "----------------------------");
        //        _simpleProduct.GetMyType();
        //        _biologicalProduct.GetMyType();
        //        _chemicalProduct.GetMyType();
        //    }
        //}



        //public class Provider : Concept
        //{
        //    //Attributes
        //    //private int _id;
        //    private string _userName = string.Empty;
        //    private string _email = string.Empty;
        //    private string _password = string.Empty;
        //    private string _confirmPassword = string.Empty;
        //    //private DateTime _dateCreated;
        //    private bool _isApproved = false;
        //    //private IList<Product> _products = new List<Product>();

        //    //Properties
        //    public int Id { get; set; }
        //    public string UserName { get; set; } = string.Empty;
        //    public string Email { get; set; } = string.Empty;

        //    public string Password
        //    {
        //        get => _password;
        //        set
        //        {
        //            if (_password.Length >= 5 && _password.Length <= 20)
        //                _password = value;
        //            else { Console.WriteLine("Le mot de passe doit contenir entre 5 et 20 caractères."); }
        //        }
        //    }

        //    public string ConfirmPassword
        //    {
        //        get => _confirmPassword;
        //        set
        //        {
        //            if (_password == value)
        //                _confirmPassword = value;
        //            else { Console.WriteLine("Les deux mots de passe que vous avez saisis ne sont pas identiques."); }
        //        }
        //    }

        //    public DateTime DateCreated { get; set; }

        //    public bool IsApproved { get => _isApproved; set => _isApproved = value; }

        //    public IList<Product> Products { get; set; } = default!;

        //    //Methods
        //    public override void GetDetails()
        //    { throw new NotImplementedException(); }

        //    //Login - Methods 1 and 2 (expression body form), combined in the "Login" method below:
        //    //public bool LoginMethod1(string _userName, string _password) => _userName == this._userName && _password == this._password;
        //    //public bool LoginMethod2(string _userName, string _password, string _email) => _userName == this._userName && _password == this._password && _email == this._email;
        //    public bool Login(string _userName, string _password, string _email = "")
        //    {
        //        if (!string.IsNullOrEmpty(_email))
        //        {
        //            return _userName == this._userName
        //                && _password == this._password
        //                && _email == this._email;
        //        }
        //        else
        //        {
        //            return _userName == this._userName
        //                && _password == this._password;
        //        }
        //    }

        //    //public static void SetIsApproved(Provider P)
        //    //{
        //    //    P._isApproved = P._password == P._confirmPassword;
        //    //    Console.WriteLine($"Vous avez saisi \"{P._password}\" comme mot de passe et \"{P._confirmPassword}\" comme confirmation.");
        //    //    if (P._isApproved == true)
        //    //    { Console.WriteLine("Les deux saisies sont identiques. Votre accès est approuvé."); }
        //    //    else { Console.WriteLine("Les deux saisies ne sont pas identiques. Votre accès est refusé."); }
        //    //}

        //    public static void SetIsApproved(string password, string confirmPassword, bool isApproved)
        //    {
        //        isApproved = password == confirmPassword;
        //        Console.WriteLine($"Vous avez saisi \"{password}\" comme mot de passe et \"{confirmPassword}\" comme confirmation.");
        //        if (isApproved == true)
        //        { Console.WriteLine("Les deux saisies sont identiques. Votre accès est approuvé."); }
        //        else { Console.WriteLine("Les deux saisies ne sont pas identiques. Votre accès est refusé."); }
        //    }

        //    ////public static void SetIsApproved(Provider P)
        //    ////{
        //    ////    P.IsApproved = (P.Password == P.ConfirmPassword);
        //    ////    Console.WriteLine();
        //    ////}

        //    //public static void SetIsApproved(Provider _provider)
        //    //{
        //    //    _provider.IsApproved = _provider.Password == _provider.ConfirmPassword;
        //    //    Console.WriteLine($"Vous avez tapé \"{}\" "
        //    //        );

        //    //}

        //    //public static void SetIsApproved(string _password, string _confirmPassword, bool _isApproved)
        //    //{ _isApproved = _password == _confirmPassword; }

        //}
    }
}
