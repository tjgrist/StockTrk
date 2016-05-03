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

            api.setURL(user);
            user.promptOptions(api);
            Console.ReadKey();
        }
    }
}
