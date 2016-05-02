using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; //for WebClient

namespace StockTrk
{
    class YahooFinance
    {
        WebClient web = new WebClient();
        Stock stocks = new Stock();
        string yahooUrl;
        string csvData;

        public YahooFinance()
        {
            //change this constructor when program is more established. 
            yahooUrl = "http://download.finance.yahoo.com/d/quotes.csv?s=MSFT,PLXS,BTCUSD=X&f=nsop2";
            //showData(yahooUrl);
        }

        public string Csv
        {
            get { return csvData; }
            set { csvData = value; }
        }
        public void buildURL(User user)
        {
            yahooUrl = user.buildURL();
            showData(yahooUrl);
        }
        public void showData(string yahooUrl)
        {
            csvData = web.DownloadString(yahooUrl);
            stocks.getInfo(csvData);
        }
    }
}
