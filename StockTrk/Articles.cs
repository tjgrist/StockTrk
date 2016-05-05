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
                        Console.WriteLine("Reddit post Link: " + post.Shortlink);
                        Console.WriteLine("Original Article link: " + post.Url);                       
                    }
                else
                {
                    Console.WriteLine("Sorry. No articles were found given that match your parameters");
                }
            }
        }
        public void searchUserStocks()
        {
            Reddit reddit = new Reddit();
            var subreddit = reddit.GetSubreddit("/r/stockmarket");
            foreach (var post in subreddit.New.Take(100))
            {
                foreach (string ticker in stockWatch)
                {
                    if (post.Title.Contains(ticker))
                    {
                        Console.WriteLine(post.Title);
                        Console.WriteLine("Reddit post Link: " + post.Shortlink);
                        Console.WriteLine("Original Article link: " + post.Url);
                    }                       
                }
            }
        }
    }
}
