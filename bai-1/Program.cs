using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            Menu.DisplayMenu(store);
        }
    }
}
