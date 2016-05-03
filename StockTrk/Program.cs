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
            while (true)//Set back to this: (user.Validated)
            {
                api.setURL(user);
                user.promptOptions(api);
                Console.ReadKey();
            }
        }
    }
}
