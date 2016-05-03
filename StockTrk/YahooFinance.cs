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

        protected string yahooUrl;
        protected string csvData;

        public YahooFinance()
        {
            /*change this constructor when program is more established.
            Currently using it only for viewing purposes.*/
            //yahooUrl = "http://download.finance.yahoo.com/d/quotes.csv?s=MSFT,PLXS,BTCUSD=X&f=nsop2";
            //showData(yahooUrl);
        }

        public string Csv
        {
            get { return csvData; }
            set { csvData = value; }
        }
        public string YahooUrl
        {
            get { return yahooUrl; }
            set { yahooUrl = value; }
        }
        public void setURL(User user)
        {
            yahooUrl = user.buildURL();
            showData(yahooUrl);
        }
        public void showData(string yahooUrl)
        {
            WebClient web = new WebClient();
            Stock stocks = new Stock();
            csvData = web.DownloadString(yahooUrl);
            stocks.getInfo(csvData);
        }
        public void changeUrlStocks(string replacableStock,string newStock)
        {
            //Change the url based on string input in stocks.changeStocks()
            yahooUrl = yahooUrl.Replace(replacableStock, newStock);
            showData(yahooUrl);
        }
    }
}
