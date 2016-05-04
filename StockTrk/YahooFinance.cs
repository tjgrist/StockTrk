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
            //
        }
        public void setURL(User user, Stock market)
        {
            yahooUrl = user.buildURL(market);
            showData(yahooUrl, market);
        }
        public void showData(string yahooUrl,Stock market)
        {
            csvData = web.DownloadString(yahooUrl);
            market.getInfo(csvData);
        }
        public void downloadCsv()
        {
            Uri uri = new Uri(YahooUrl);
            web.DownloadFileAsync(uri, @"C:\Downloads\StockTrkStocks.csv");
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
