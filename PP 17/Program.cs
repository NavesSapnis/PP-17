using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using PP_17.Class.Hero;
using PP_17.Class.Fabric;

namespace PP_17
{
    internal class Program
    {
        public static Random rand = new Random();
        public static string InputFromPYStr(string text)
        {
            Console.WriteLine(text);
            string temp = Console.ReadLine();
            return temp;
        }
        public static double InputFromPYDouble(string text)
        {
            Console.WriteLine(text); double temp = 0; bool check = true;
            while (check)
            {
                try
                {
                    temp = Convert.ToDouble(Console.ReadLine());
                    check = false;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Вы должны ввести число");
                }
            }
            return temp;
        }
        public static int InputFromPY(string text)
        {
            Console.WriteLine(text); int temp = 0; bool check = true;
            while (check)
            {
                try
                {
                    temp = Convert.ToInt32(Console.ReadLine());
                    check = false;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Вы должны ввести число");
                }
            }
            return temp;
        }
        public static ArrayList InputRandNumbers(ArrayList arrayList)
        {
            int num = InputFromPY("Введите кол-во чисел");
            int low = InputFromPY("Введите нижний диапазон значения");
            int hight = InputFromPY("Введите верхний диапазон значения");
            Random rand = new Random();
            for (int i = 0; i < num; i++)
            {
                arrayList.Add(rand.Next(low, hight));
            }
            return arrayList;
        }

        public static ArrayList InputNumbers(ArrayList arrayList)
        {
            bool check = true; int num = 0;
            while (check)
            {
                num = InputFromPY("Введите кол-во чисел (до 5)");
                if (num > 5 || num < 0)
                {
                    Console.WriteLine("Вы дожны ввести кол-во от 1 до 5 включительно");
                }
                else
                {
                    check = false;
                }
            }
            Random rand = new Random();
            for (int i = 0; i < num; i++)
            {
                var temp = InputFromPY("Введите " + (i + 1) + " эллемент");
                if (temp > 0)
                {
                    Console.Clear();
                    Console.WriteLine("низя не отрицательные числа вводить\nначните с начала");
                    arrayList.Clear();
                    i = 0;
                }
                else
                    arrayList.Add(temp);
            }
            return arrayList;
        }
        public static void PrintElements(ArrayList arrayList)
        {
            for (int i = 0; i < arrayList.Count; i++)
            {
                Console.WriteLine((i + 1) + ") " + arrayList[i]);
            }
        }
        public static ArrayList DeleteElements(ArrayList arrayList)
        {
            for (int i = 0; i < arrayList.Count; i += 2)
            {
                if (Convert.ToInt32(arrayList[i]) < 0)
                {
                    arrayList.RemoveAt(i);
                }
            }
            return arrayList;
        }
        public static Hero GetHero()
        {
            Hero hero = new Hero(InputFromPYStr("Введите имя\n"), InputFromPY("Введите hp\n"), "", InputFromPY("Введите кол-во мечей\n"));
            return hero;
        }
        public static void PrintElements(List<Hero> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                Console.Write((i + 1) + ")");
                arr[i].PrintInfo();
            }
        }
        public static Hero MinHero(List<Hero> arr)
        {
            int min = arr[0].SwordCount;
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i].SwordCount < min)
                {
                    min = arr[i].SwordCount;
                }
            }
            for (int i = 0; i < arr.Count; i++)
            {
                if (min == arr[i].SwordCount)
                {
                    return arr[i];
                }
            }
            return arr[0];
        }
        public static List<Hero> DeleteHero(List<Hero> arr)
        {
            Hero min = new Hero();
            for (int i = 0; i < 3; i++)
            {
                min = MinHero(arr);
                arr.Remove(min);
            }
            return arr;
        }
        public static HashSet<Fabric> GetFabricsStart(HashSet<Fabric> set)
        {
            string[] colors = { "зеленый", "красный", "фиолетовый", "розовый", "зеленый", "оранжевый", "голубой" };
            for (int i = 0; i < 10; i++)
            {
                Fabric fabric = new Fabric(colors[rand.Next(7)], rand.Next(10, 100));
                set.Add(fabric);
            }
            return set;
        }
        //public static HashSet<Fabric> GetFabrics(HashSet<Fabric> set)
        //{

        //    Fabric fabric = new Fabric(InputFromPYStr("Введите цвет"), InputFromPYDouble("Введите длину"));

        //}
        static void Main(string[] args)
        {
            ArrayList numberList = new ArrayList();
            List<Hero> heros = new List<Hero>();
            HashSet<Fabric> fabrics = new HashSet<Fabric>();
            fabrics = GetFabricsStart(fabrics);
            while (true)
            {
                try
                {
                    switch (Menu.StartMenu("1 - задание с ArrayList\n2 - задание с героем\n3 - задание 3\n4 - задание с тканью"))
                    {
                        case 1:
                            Console.Clear();
                            bool che = true;
                            while (che)
                            {
                                switch (Menu.StartMenu("1 - заполнить рандомными числами\n2 - добавить отрицательных чисел\n3 - удалить каждое отрицательное число на четном месте\n4 - вывести ArrayList\n5 - выйти"))
                                {
                                    case 1:
                                        Console.Clear();
                                        numberList = InputRandNumbers(numberList);
                                        break;
                                    case 2:
                                        Console.Clear();
                                        numberList = InputNumbers(numberList);
                                        break;
                                    case 3:
                                        Console.Clear();
                                        numberList = DeleteElements(numberList);
                                        break;
                                    case 4:
                                        Console.Clear();
                                        PrintElements(numberList);
                                        break;
                                    case 5:
                                        Console.Clear();
                                        che = false;
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("такого выбора нет");
                                        break;
                                }
                            }
                            break;
                        case 2:
                            Console.Clear();
                            bool che2 = true;
                            while (che2)
                            {
                                switch (Menu.StartMenu("1 - добавить героя\n2 - добавить Геральта\n3 - удалить героев, у которых кол-во мечей меньше 2\n4 - вывести всех героев\n5 - выйти"))
                                {
                                    case 1:
                                        Console.Clear();
                                        Hero temp = GetHero();
                                        heros.Add(temp);
                                        break;
                                    case 2:
                                        Console.Clear();
                                        heros.Add(new Hero("Херальд", 2000, "", 2));
                                        break;
                                    case 3:
                                        Console.Clear();
                                        heros = DeleteHero(heros);
                                        break;
                                    case 4:
                                        Console.Clear();
                                        PrintElements(heros);
                                        break;
                                    case 5:
                                        Console.Clear();
                                        che2 = false;
                                        break;

                                }
                            }
                            break;
                        case 3:
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Такого выбора нет");
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Вы не выбрали число");
                }
            }
        }
    }
}
