using Microsoft.EntityFrameworkCore;

namespace TR.Domain
{
    [Owned]
    public class Address
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }

    }
}