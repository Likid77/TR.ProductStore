using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.Domain
{
    public class Biological : Product
    {
        // Properties
        // ==========
        public string Herbs { get; set; } = string.Empty;


        // Methods
        // =======
        public override void GetDetails() => base.GetDetails();
        public override void GetMyType() => Console.WriteLine("BIOLOGIQUE");
    }
}
