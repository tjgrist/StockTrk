using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; //for WebClient

namespace StockTrk
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient web = new WebClient();
            string yahooUrl = "http://download.finance.yahoo.com/d/quotes.csv?s=PLXS";
            string csvData = web.DownloadString(yahooUrl);
            Console.WriteLine(csvData);
            Console.ReadKey();



        }
    }
}
