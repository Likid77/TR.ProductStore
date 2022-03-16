using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.Domain
{
    public class Chemical : Product
    {
        // Properties
        // ==========
        public string LabName { get; set; } = string.Empty;
        //public string StreetAddress { get; set; } = string.Empty;
        //public string City { get; set; } = string.Empty;
        public Address Address { get; set; }

        // Methods
        // =======
        public override void GetDetails() => base.GetDetails();
        public override void GetMyType() => Console.WriteLine("CHIMIQUE");
    }
}
