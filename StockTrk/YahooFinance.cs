using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace StockTrk
{
    class YahooFinance
    {
        protected string yahooUrl;
        protected string csvData;
        string downloadLocation = @"C:\Downloads\StockTrkStocks.csv";
        WebClient web = new WebClient();

        public YahooFinance()
        {
            yahooUrl = "http://download.finance.yahoo.com/d/quotes.csv?s=";
        }
        public void setURL(User user, Stocks market, YahooFinance api)
        {
            yahooUrl = user.buildURL(market, api);
            showData(yahooUrl, market);
        }
        public void showData(string yahooUrl,Stocks market)
        {
            csvData = web.DownloadString(yahooUrl);
            market.getInfo(csvData);
        }
        public void downloadCsv()
        {
            Uri uri = new Uri(YahooUrl);
            web.DownloadFileAsync(uri, downloadLocation);
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
    }
}
