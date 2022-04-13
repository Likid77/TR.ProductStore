using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.Domain
{
    public class Product : Concept
    {
        // Properties
        // ==========
        public uint ProductId { get; set; }
        
        [Required(ErrorMessage ="Merci d'ajouter votre nom.")]
        [StringLength(25, ErrorMessage ="Ce champ doit contenir 25 caractères maximum.")]
        [MaxLength(50, ErrorMessage = "Cette propriété doit contenir 50 caractères maximum.")]
        public string Name { get; set; } = string.Empty;
        
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;
        
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Range(0, int.MaxValue)]
        public uint Quantity { get; set; }

        [Display(Name = "Production Date")]
        [DataType(DataType.Date)]
        public DateTime DateProd { get; set; }


        [ForeignKey("Category") ] // En rouge, le nom de la propriété de navigation (et non de la classe)
        public uint? CategoryId { get; set; } // "?" = variable nullable
        public string Image { get; set; }

        // Navigation properties
        // =====================
        //[ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public virtual IList<Provider> Providers { get; set; } = new List<Provider>();
        public virtual IList<Client> Clients { get; set; } = new List<Client>();
        public virtual IList<Facture> Factures { get; set; } = new List<Facture>();

        // Methods
        // =======
        public override void GetDetails() => Console.WriteLine(
                $"Id : {ProductId}\n" +
                $"Désignation : {Name}\n" +
                $"Description : {Description}\n" +
                $"Prix d'achat (-10%) : {Price * .9:0.000} DT\n" +
                $"Prix de vente : {Price:0.000} DT\n" +
                $"Quantité en stock : {Quantity:# ###} unités\n" +
                $"Date de production : {DateProd:ddd dd/MM/yyyy}");

        public virtual void GetMyType() => Console.WriteLine("DE TYPE INDÉTERMINÉ");
    }
}
