using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.Domain;


namespace TR.Service
{
    public static class ProductExtension
    {
        public static void UpperName(this ProductManage productManage)
        {
            foreach (var product in productManage.Products)
            {
                product.Name = product.Name.ToUpper();
            }
        }

        public static bool InCategory(this ProductManage productManage, Category category)
        {
            foreach (var product in productManage.Products)
            {
                if (product.Category == category)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
