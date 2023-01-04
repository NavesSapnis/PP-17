using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_17.Class.Hero
{
    internal class Hero
    {
        private string name;
        private int hp;
        private string status;
        private int swordsCount;

        public string Name { get { return name; } set { name = value; } }
        public int Hp { get { return hp; } set { hp = value; } }
        public string Status
        {
            get { return status; }
            set
            {
                if (Hp < 500)
                {
                    status = "устал";
                }
                if (Hp < 0)
                {
                    status = "мертв";
                }
                else
                {
                    status = "жив";
                }
            }
        }
        public int SwordCount 
        { 
            get { return swordsCount; } 
            set 
            {
                if (value < 0)
                {
                    throw new Exception("Кол-во мечей не может быть меньше 0");
                }
                else
                {
                    swordsCount = value;
                }
            } 
        }

        public Hero() { }
        public Hero(string name, int hp, string status, int swordCount)
        {
            Name = name;
            Hp = hp;
            Status = status;
            SwordCount = swordCount;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Имя - {Name}\nХп - {Hp}\nСтатус - {Status}\nКол-во мечей - {SwordCount}\n");
        }
    }
}
