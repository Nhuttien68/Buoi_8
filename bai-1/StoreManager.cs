using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace bai_1
{
    public static class Menu
    {
        public static void DisplayMenu(Store store)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nMENU:");
                Console.WriteLine("1. Add Products");
                Console.WriteLine("2. Purchase Products");
                Console.WriteLine("3. Check Expiry");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
                {
                    Console.WriteLine("Invalid choice. Please enter again.");
                    Console.Write("Enter your choice: ");
                }

                switch (choice)
                {
                    case 1:
                        AddProduct(store);
                        break;
                    case 2:
                        BuyProduct(store);
                        break;
                    case 3:
                        CheckExpiry(store);
                        break;
                    case 4:
                        exit = true;
                        Console.WriteLine("Exiting the program.");
                        break;
                }
            }
        }

        public static void AddProduct(Store store)
        {
            Console.WriteLine("\nNhập thông tin sản phẩm:");
            Console.Write("Mã sản phẩm: ");
            int productID;
            while (!int.TryParse(Console.ReadLine(), out productID) || productID <= 0)
            {
                Console.WriteLine("Mã sản phẩm không hợp lệ. Vui lòng nhập lại.");
                Console.Write("Mã sản phẩm (số nguyên): ");
            }
            Console.Write("Tên sản phẩm: ");
            string productName = Console.ReadLine();
            if (!IsValidProductName(productName))
            {
                Console.WriteLine("Tên sản phẩm không được chứa kí tự đặc biệt hoặc khoảng trắng. Vui lòng nhập lại.");
                return;
            }
            Console.Write("Giá tiền: ");
            double productPrice;
            while (!double.TryParse(Console.ReadLine(), out productPrice) || productPrice <= 0)
            {
                Console.WriteLine("Giá tiền không hợp lệ. Vui lòng nhập lại.");
                Console.Write("Giá tiền: ");
            }
            Console.Write("Ngày sản xuất (dd/MM/yyyy): ");
            DateTime productManufacturingDate;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out productManufacturingDate))
            {
                Console.WriteLine("Ngày sản xuất không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.");
                Console.Write("Ngày sản xuất (dd/MM/yyyy): ");
            }
            Console.Write("Ngày hết hạn (dd/MM/yyyy): ");
            DateTime productExpiryDate;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out productExpiryDate))
            {
                Console.WriteLine("Ngày hết hạn không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy.");
                Console.Write("Ngày hết hạn (dd/MM/yyyy): ");
            }

            Console.WriteLine("\nChọn loại sản phẩm:");
            Console.WriteLine("1. Hàng điện tử");
            Console.WriteLine("2. Hàng thực phẩm");
            Console.WriteLine("3. Hàng quần áo");
            Console.Write("Nhập lựa chọn của bạn: ");
            int productType;
            while (!int.TryParse(Console.ReadLine(), out productType) || productType < 1 || productType > 3)
            {
                Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại.");
                Console.Write("Nhập lựa chọn của bạn: ");
            }

            switch (productType)
            {
                case 1:
                    store.AddProduct(new ElectronicsProduct(productID, productName, productPrice, productManufacturingDate));
                    break;
                case 2:
                    store.AddProduct(new FoodProduct(productID, productName, productPrice, productManufacturingDate, productExpiryDate));
                    break;
                case 3:
                    store.AddProduct(new ClothingProduct(productID, productName, productPrice, productManufacturingDate));
                    break;
            }
            Console.WriteLine("Đã thêm sản phẩm thành công.");
        }

        public static void BuyProduct(Store store)
        {
            Console.Write("\nNhập mã sản phẩm bạn muốn mua: ");
            string productCode = Console.ReadLine();
            store.BuyProduct(productCode);
        }

        public static void CheckExpiry(Store store)
        {
            store.CheckExpiryProducts();
        }
        private static bool IsValidProductName(string name)
        {
            foreach (char c in name)
            {
                if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                {
                    return false;
                }
            }
            return true;
        }
    }

}
