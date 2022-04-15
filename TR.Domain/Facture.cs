namespace TR.Domain
{
    public class Facture
    {

        // Properties
        // ==========
        public uint ClientFk { get; set; }
        public uint ProductFk { get; set; }
        public DateTime DateAchat { get; set; }
        public float Prix { get; set; }

        // Navigation properties
        // =====================
        //[ForeignKey("ClientFk")]
        public virtual Client Client { get; set; }
        //[ForeignKey("ProductFk")]
        public virtual Product Product { get; set; }
    }
}
