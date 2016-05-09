using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StockTrk
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            YahooFinance api = new YahooFinance();
            Stocks market = new Stocks();
            if (user.Validated)
            {
                Console.WriteLine("\nWelcome to StockTrk, your personalized tech-stock tracker.");
                api.setURL(user, market, api);
                user.displayOptions(api, market);
                Console.WriteLine("Thanks for using StockTrk!");
                Console.ReadKey();
            }
            else
            {
                Main(args);
            }
        }
    }
}
