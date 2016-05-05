using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditSharp;

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
            foreach (var post in subreddit.Hot.Take(200))
            {
                if (post.Title.ToLower().Contains("tech"))
                    {
                        Console.WriteLine(post.SubredditName + "\n" + post.Title);
                        Console.WriteLine("Reddit Score: " + post.Score);
                        Console.WriteLine("Reddit post Link: " + post.Shortlink + "\n");                    
                    }
            }
        }
        public void searchUserStocks()
        {
            Reddit reddit = new Reddit();
            var subreddit = reddit.GetSubreddit("/r/stockmarket");
            foreach (var post in subreddit.New.Take(200))
            {
                foreach (string ticker in stockWatch)
                {
                    if (post.Title.Contains(ticker))
                    {
                        Console.WriteLine(post.Title);
                        Console.WriteLine("Reddit post Link: " + post.Shortlink + "\n");
                        Console.WriteLine(post.Domain);
                    }                    
                }    
            }
            if (stockWatch.Contains("BTCUSD=X"))
                {
                    getBitcoinArticles(reddit); 
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
