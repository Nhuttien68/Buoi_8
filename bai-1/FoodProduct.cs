using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_1
{
    public class FoodProduct : Product
    {
        public FoodProduct(int productID, string productName, double productPrice, DateTime productManufacturingDate,DateTime productExpiryDate)
            : base(productID, productName, productPrice, productManufacturingDate, productExpiryDate)
        {
        }
    }
}
