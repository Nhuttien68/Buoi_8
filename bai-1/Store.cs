using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_1
{
    public class Store
    {
        private List<Product> products;

        public Store()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void DisplayProducts()
        {
            Console.WriteLine("\nDanh sách sản phẩm trong cửa hàng:");
            foreach (var product in products)
            {
                string expiryInfo = product.productExpiryDate != null ? $", Ngày hết hạn: {((DateTime)product.productExpiryDate).ToString("dd/MM/yyyy")}" : "";
                Console.WriteLine($"Mã hàng: {product.productID}, Tên hàng: {product.productName}, Giá tiền: {product.productPrice}, Ngày sản xuất: {product.productManufacturingDate.ToString("dd/MM/yyyy")}{expiryInfo}");
            }
        }

        public void BuyProduct(string productCode)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].productID.ToString() == productCode)
                {
                    products.RemoveAt(i);
                    Console.WriteLine("Mua hàng thành công.");
                    return;
                }
            }
            Console.WriteLine("Không tìm thấy sản phẩm có mã hàng này.");
        }

        public void CheckExpiryProducts()
        {
            Console.WriteLine("\nCác sản phẩm sắp hết hạn:");
            foreach (var product in products)
            {
                if (product.productExpiryDate != null)
                {
                    TimeSpan remainingDays = (DateTime)product.productExpiryDate - DateTime.Now;
                    if (remainingDays.TotalDays < 30)
                    {
                        Console.WriteLine($"Mã hàng: {product.productID}, Tên hàng: {product.productName}, Ngày hết hạn: {((DateTime)product.productExpiryDate).ToString("dd/MM/yyyy")}, Số ngày còn lại: {remainingDays.Days}");
                    }
                }
            }
        }

    }

}
