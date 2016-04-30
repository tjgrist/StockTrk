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
            string yahooUrl = "http://download.finance.yahoo.com/d/quotes.csv?s=NYSE,AAPL,MSFT,PLXS,YHOO,BTCUSD=X&f=nab";
            string csvData = web.DownloadString(yahooUrl);
            YahooFinance accountant = new YahooFinance();
            accountant.getInfo(csvData);
            Console.ReadKey();



        }
    }
}
