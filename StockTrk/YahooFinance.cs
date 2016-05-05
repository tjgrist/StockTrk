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
        string yahooUrl;
        string csvData;
        string downloadLocation;

        public string YahooUrl
        {
            get { return yahooUrl; }
            set { yahooUrl = value; }
        }
        public string Csv
        {
            get { return csvData; }
            set { csvData = value; }
        }
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
            WebClient web = new WebClient();
            csvData = web.DownloadString(yahooUrl);
            market.displayStockInfo(csvData); 
        }
        public void downloadCsv()
        {
            WebClient web = new WebClient();
            Uri uri = new Uri(YahooUrl);
            downloadLocation = @"C:\Downloads\StockTrkStocks.csv";
            web.DownloadFileAsync(uri, downloadLocation);
        }
    }
}
