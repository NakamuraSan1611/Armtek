using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armtek
{
    public class Armtek
    {
        public string PIN { get; set; }
        public string BRAND { get; set; }
        public string NAME { get; set; }
        public string ARTID { get; set; }
        public string PARNR { get; set; }
        public string KEYZAK { get; set; }
        public string RVALUE { get; set; }
        public string RDPRF { get; set; }
        public string MINBM { get; set; }
        public string VENSL { get; set; }
        public double PRICE { get; set; }
        public void PrintPrice(string price)
        {
            Console.WriteLine(string.Format("Цена: {0:##,####}", price));
        }
    }
}
