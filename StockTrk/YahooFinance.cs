using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrk
{
    class YahooFinance
    {
        public void getInfo(string csvData)
        {
            List<string> dataList = new List<string>();
            dataList = csvData.Split('\n').ToList();
            foreach (string stock in dataList)
            {
                Console.WriteLine("++"+stock);

            }
        }
    }
}
