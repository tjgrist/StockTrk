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
        WebClient web = new WebClient();

        public YahooFinance()
        {
            //Can put potentially put User instance here.
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
            Stock stocks = new Stock();
            csvData = web.DownloadString(yahooUrl);
            stocks.getInfo(csvData);
        }
        public void downloadCsv()
        {
            //Downloads to local directory.
            Uri uri = new Uri(YahooUrl);
            web.DownloadFileAsync(uri, @"C:\Downloads\StockTrkStocks.csv");
        }
    }
}
