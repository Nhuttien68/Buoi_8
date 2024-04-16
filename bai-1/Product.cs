using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_1
{
    public class Product
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public double productPrice { get; set; }
        public DateTime productManufacturingDate { get; set; }
        public DateTime productExpiryDate { get; set; } 

        public Product(int productID, string productName, double productPrice, DateTime productManufacturingDate, DateTime? productExpiryDate = null)
        {
            productID = productID;
            productName = productName;
            productPrice = productPrice;
            productManufacturingDate = productManufacturingDate;
            productExpiryDate = productExpiryDate;
        }
    }
}
