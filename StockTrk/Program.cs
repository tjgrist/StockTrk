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
            while (true)//Set back to this: (user.Validated)
            {
                YahooFinance accountant = new YahooFinance();
                accountant.buildURL(user);
                user.promptOptions();
                Console.ReadKey();
            }
        }
    }
}
