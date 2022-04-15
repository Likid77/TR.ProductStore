using System.ComponentModel.DataAnnotations;

namespace TR.Domain
{
    public class Client
    {
        // Properties
        // ==========
        [Key]
        public uint CIN { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }

        [EmailAddress]
        public string Mail { get; set; }

        // Navigation properties
        // =====================
        public virtual IList<Product> Products { get; set; }
        public virtual IList<Facture> Factures { get; set; }
    }
}
