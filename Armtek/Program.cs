using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armtek
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            string line;
            StringBuilder sb = new StringBuilder();
            System.IO.StreamReader file = new System.IO.StreamReader(Path.Combine(Directory.GetCurrentDirectory() + @"\Armtek.txt"));


            while ((line = file.ReadLine()) != null)
            {
                sb.Append(line);
            }


            List<Armtek> products = new List<Armtek>();
            var splitSTR = sb.ToString().Replace("[", "").Replace("{", "").Replace("},", "}").Split('}');


            foreach (var item in splitSTR)
                try
                {
                    {
                        var test = item.Replace("',", "#").Split('#');
                        Armtek product = new Armtek();
                        foreach (var items in test)
                        {
                            var res = items.Split(':');
                            var key = res[0].Replace("'", "");
                            var value = res[1].Replace("'", "");
                            #region
                            switch (key)
                            {
                                case "PIN":
                                    product.PIN = value;
                                    break;
                                case "BRAND":
                                    product.BRAND = value;
                                    break;
                                case "NAME":
                                    product.NAME = value;
                                    break;
                                case "ARTID":
                                    product.ARTID = value;
                                    break;
                                case "PARNR":
                                    product.PARNR = value;
                                    break;
                                case "KEYZAK":
                                    product.KEYZAK = value;
                                    break;
                                case "RVALUE":
                                    product.RVALUE = value;
                                    break;
                                case "RDPRF":
                                    product.RDPRF = value;
                                    break;
                                case "MINBM":
                                    product.MINBM = value;
                                    break;
                                case "VENSL":
                                    product.VENSL = value;
                                    break;
                                case "PRICE":
                                    product.PRICE = Double.Parse(value.Replace('.', ','));
                                    break;
                            }
                            #endregion
                        }
                        products.Add(product);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    count++;
                }

            Console.WriteLine("Удачно отработанные: " + products.Count);
            Console.WriteLine("Неудачно отработанные: " + count);
            Console.WriteLine("Всего: " + splitSTR.Length);

            while (true)
            {
                Console.WriteLine("1. Поиск\n2. Отсортировать\n3. Вывести все!\n4. quit чтобы выйти");
                string choice = Console.ReadLine();
                if (choice == "quit")
                    break;
                int choiceI = Int32.Parse(choice);
                switch (choiceI)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("Поиск по\n1. По номеру запчасти\n2. По бренренду\n3. По совпадению в наименовании\n4. По \"Keyzak\"");
                            int toShowI = Int32.Parse(Console.ReadLine());
                            switch (toShowI)
                            {
                                case 1: find1(); break;
                                case 2: find2(); break;
                                case 3: find3(); break;
                                case 4: find4(); break;
                                default: break;
                            }
                        }
                        break;
                    case 2: sort(); break;
                    case 3: show(); break;
                    default: Console.WriteLine("ощибка!"); break;
                }
                Console.ReadKey();
                Console.Clear();
            }
            void find1()
            {
                Console.WriteLine("Введите номер запчасти (ARTID):");
                string id = Console.ReadLine();
                foreach (var item in products)
                {
                    if (item.ARTID == id)
                        Console.WriteLine(item.BRAND + "\t" + item.ARTID + "\t" + item.PIN + "\t" + item.NAME + "\t" + item.PRICE + "\t" + item.RVALUE + "\n");
                }
            }
            void find2()
            {
                Console.WriteLine("Введите название брЭнда (BRAND):");
                string brand = Console.ReadLine();
                foreach (var item in products)
                {
                    if (item.BRAND == brand)
                        Console.WriteLine(item.BRAND + "\t" + item.ARTID + "\t" + item.PIN + "\t" + item.NAME + "\t" + item.PRICE + "\t" + item.RVALUE + "\n");
                }
            }
            void find3()
            {
                Console.WriteLine("Введите наименование (NAME):");
                string name = Console.ReadLine();
                foreach (var item in products)
                {
                    if (item.NAME.Contains(name))
                        Console.WriteLine(item.BRAND + "\t" + item.ARTID + "\t" + item.PIN + "\t" + item.NAME + "\t" + item.PRICE + "\t" + item.RVALUE + "\n");
                }
            }
            void find4()
            {
                Console.WriteLine("Введите наименование (KEYZAK):");
                string name = Console.ReadLine();
                foreach (var item in products)
                {
                    if (item.KEYZAK == name)
                        Console.WriteLine(item.BRAND + "\t" + item.ARTID + "\t" + item.PIN + "\t" + item.NAME + "\t" + item.PRICE + "\t" + item.RVALUE + "\n");
                }
            }
            void sort()
            {
                products = products.OrderBy(product => product.PRICE).ToList();
                Console.WriteLine("Отсортировал...");
            }
            void show()
            {
                foreach (var item in products)
                {
                    Console.WriteLine(item.PRICE);
                }
            }
            
        }
    }
}
