using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PP_17.Class.Fabric
{
    internal class Fabric
    {

        private string color;
        private double dlina;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public double Dlina
        {
            get { return dlina; }
            set 
            {
                if (value < 0)
                {
                    throw new Exception("Длина не может быть меньше нуля");
                }
                else
                {
                    dlina = value;
                }
            }
        }
        public Fabric() { }
        public Fabric(string color,double dlina) 
        {
            Color = color;
            Dlina = dlina;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Цвет - {Color}\nДлина - {Dlina}\n");
        }
        
    }
}
