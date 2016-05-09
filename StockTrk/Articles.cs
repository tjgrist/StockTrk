using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditSharp;
using System.Diagnostics;

namespace StockTrk
{
    class Articles
    {
        List<string> stockWatch = new List<string>();

        public List<string> StockWatch
        {
            get { return stockWatch; }
            set { stockWatch = value; }
        }
        public void showTechFinanceArticles()
        {
            Reddit reddit = new Reddit();
            var subreddit = reddit.GetSubreddit("/r/stockmarket");
            foreach (var post in subreddit.Hot.Take(50))
            {
                if (post.Title.ToLower().Contains("tech"))
                    {
                        Console.WriteLine("Article Title: " + post.Title);
                        Console.WriteLine("Reddit post Link: " + post.Shortlink + "\n");                    
                    }
            }
        }
        public void searchUserStocks()
        {
            Reddit reddit = new Reddit();
            var subreddit = reddit.GetSubreddit("/r/stockmarket");
            foreach (var post in subreddit.New.Take(50))
            {
                foreach (string ticker in stockWatch)
                {
                    if (post.Title.Contains(ticker))
                    {
                        Console.WriteLine("Article Title: " + post.Title);
                        Console.WriteLine("Reddit post Link: " + post.Shortlink + "\n");
                        launchArticle(post.Shortlink);
                    }                    
                }    
            }
            if (stockWatch.Contains("BTCUSD=X"))
                {
                    getBitcoinArticles(reddit); 
                }
        }
        private void launchArticle(string shortlink)
        {
            Console.WriteLine("Enter 1 to launch this article.\nPress ENTER to continue.");
            string launch = Console.ReadLine();
            switch (launch)
            {
                case "1":
                    Process.Start(shortlink);
                    break;
                default:
                    break;
            }
        }
        private void getBitcoinArticles(Reddit reddit)
        {
            Console.WriteLine("\nWe thought you may want to see the trending bitcoin articles:\n");
            var subreddit = reddit.GetSubreddit("/r/Bitcoin");
            foreach (var post in subreddit.Hot.Take(25))
            {
                if (post.Score > 500)
                {
                    Console.WriteLine(post.Title + "\n" +  post.Shortlink + "\n");
                }
            }

        }
    }
}
