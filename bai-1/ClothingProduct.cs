using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_1
{
    public class ClothingProduct : Product
    {
        public ClothingProduct(int  productID, string productName, double productPrice, DateTime productManufacturingDate)
            : base(productID,productName,productPrice,productManufacturingDate)
        {
        }
    }
}
