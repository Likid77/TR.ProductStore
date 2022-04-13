using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.Domain
{
    public class Facture
    {

        // Properties
        // ==========
        public uint ClientFK { get; set; }
        public uint ProductFK { get; set; }
        public DateTime DateAchat { get; set; }
        public float Prix { get; set; }

        // Navigation properties
        // =====================
        [ForeignKey("ClientFk")]
        public virtual Client Client { get; set; }
        [ForeignKey("ProductFk")]
        public virtual Product Product { get; set; }
    }
}
