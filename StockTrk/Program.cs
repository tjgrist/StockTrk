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
            Articles stockNews = new Articles();
            User user = new User();
            YahooFinance api = new YahooFinance();
            Stocks market = new Stocks();
            if (user.Validated)
            {
                Console.WriteLine("Welcome to Stocktrk, your personalized tech-stock tracker.");
                api.setURL(user, market, api);
                user.promptOptions(api, market);
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
