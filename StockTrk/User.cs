﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;

namespace StockTrk
{
    class User
    {
        string email;
        bool validated;
        string stocks;
        string stockCharacters;
        string baseUrl;
        string fullUrl;
        Articles stockNews = new Articles();

        public bool Validated
        {
            get { return validated; }
            set { validated = value; }
        }
        public User()
        {
            Console.WriteLine("Sign in with your email:\n");
            email = Console.ReadLine();
            if (Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                validated = true;
            }
            else
            {
                Console.WriteLine("Invalid entry.\n");
            }
        }
        public string buildURL(Stocks market, YahooFinance api)
        {
            baseUrl = api.YahooUrl;
            Console.Write("\nWhich STOCKS would you like to view?\nSeparate your stock symbols with commas." + market.showCommonStocks());
            stocks = Console.ReadLine().ToUpper().Replace(" ","");
            setStockList(stocks);
            Console.WriteLine("Add the stock info you would like to see.\n" + market.showCommonQuotes());
            stockCharacters = Console.ReadLine().ToUpper().Replace(" ","").Replace(",","");
            market.StockQuotes = "NS" + stockCharacters;
            fullUrl = baseUrl + stocks + "&f=NS" + stockCharacters;
            return fullUrl;
        }       
        public void displayOptions(YahooFinance api, Stocks market)
        {
            bool options = true;
            while (options)
            {
                printOptionString();
                options = userChooses(api, market);
            }
        }
        private bool userChooses(YahooFinance api, Stocks market)
        {
            string response = Console.ReadLine().ToLower().Replace(" ", "");
            switch (response)
            {
                case "1":
                    changeStocks(api);
                    return true;
                case "2":
                    changeQuotes(api, market);
                    return true;
                case "3":
                    viewStocks(api, market);
                    return true;
                case "4":
                    api.downloadCsv();
                    Console.WriteLine("\nA .csv file was DOWNLOADED to your Downloads folder.\n");
                    return true;
                case "5":
                    showRedditOptions();
                    return true;
                case "6":
                    setPriceAlert(market);
                    return true;
                case "q":
                    return false;
                default:
                    return true;
            }
        }
        private void changeStocks(YahooFinance api)
        {
            Console.WriteLine("Which stock would you like to REPLACE or REMOVE?");
            string replacableStock = Console.ReadLine().ToUpper();
            Console.WriteLine("Press ENTER to remove this stock: {0}.\nOR, type the stock(s) with which you'd like to REPLACE {0}.", replacableStock);
            string newStock = Console.ReadLine().ToUpper();
            api.YahooUrl = api.YahooUrl.Replace(replacableStock, newStock);
            setStockList(newStock);
        }
        private void changeQuotes(YahooFinance api, Stocks market)
        {
            Console.WriteLine("Enter 1 to REPLACE quote(s).\nEnter 2 to ADD quotes.");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    replaceQuotes(api, market);
                    break;
                case "2":
                    addQuotes(api, market);
                    break;
                default:
                    break;
            }
        }
        private void replaceQuotes(YahooFinance api, Stocks market)
        {
            Console.WriteLine("Which QUOTE(s) would you like to REPLACE or REMOVE?");
            string replacementQuote = Console.ReadLine().ToUpper().Replace(" ", "").Replace(",", "");
            Console.WriteLine("Which Quote(s) would you like to replace it with?\nPress ENTER to REMOVE your input quotes.");
            string newQuote = Console.ReadLine().ToUpper().Replace(" ", "").Replace(",", "");
            api.YahooUrl = api.YahooUrl.Remove(api.YahooUrl.IndexOf(market.StockQuotes));
            market.StockQuotes = market.StockQuotes.Replace(replacementQuote, newQuote);
            api.YahooUrl = api.YahooUrl + market.StockQuotes;
        }
        private void addQuotes(YahooFinance api, Stocks market)
        {
            Console.WriteLine("Which QUOTE(s) would you like to ADD?\n" + market.showCommonQuotes());
            string addQuotes = Console.ReadLine().ToUpper().Replace(" ", "").Replace(",", "");
            api.YahooUrl = api.YahooUrl + addQuotes;
            market.StockQuotes = market.StockQuotes + addQuotes;
        }
        private void viewStocks(YahooFinance api, Stocks market)
        {
            api.showData(api.YahooUrl, market);
        }
        private void setPriceAlert(Stocks market)
        {
            Console.WriteLine("For which stock would you like an alert?");
            string alertStock = Console.ReadLine().ToUpper();
            market.alert.AlertStock = alertStock;
            Console.WriteLine("At what price (or lower) would you like an alert for {0}?",alertStock);
            string priceAlert = Console.ReadLine();
            market.alert.AskPriceAlert = priceAlert;       
        }
        private void showRedditOptions()
        {
            Console.WriteLine("Enter 1 to search tech-related articles.\n"
                + "Enter 2 to search the subreddit for your tracked stocks.");
            string number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    stockNews.showTechFinanceArticles();
                    break;
                case "2":
                    stockNews.searchUserStocks();
                    break;
                default:
                    break;
            }
        }
        private void setStockList(string stocks)
        {
            string[] stocksToAdd = stocks.Split(',');
            foreach (string stock in stocksToAdd)
            {
                stockNews.StockWatch.Add(stock);
            }
        }
        private void printOptionString()
        {
            Console.WriteLine("Enter 1 to CHANGE STOCKS.\n"
            + "Enter 2 to CHANGE stock QUOTES.\n"
            + "Enter 3 to VIEW your TRACKED stocks.\n"
            + "Enter 4 to DOWNLOAD a CSV file of your stock portfolio.\n"
            + "Enter 5 to SEARCH for ARTICLES from Reddit's StockMarket subreddit.\n"
            + "Enter 6 to SET a PRICE DIP ALERT for a specific stock.\n"
            + "Enter 'Q' to QUIT these options.");
        }
    }
}
