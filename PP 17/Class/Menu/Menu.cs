using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_17
{
    internal class Menu
    {
        public static int StartMenu(string text)
        {
            Console.WriteLine(text);
            int a = Convert.ToInt32(Console.ReadLine());
            return a;
        }
    }
}
