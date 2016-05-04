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
        Reddit reddit = new Reddit();

        public void showTechFinanceArticles(YahooFinance api)
        {
            //Take in stock choices of user, get their names, then grab articles from Reddit based on their names.
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
            }
        }
        public void showRedditURL()
        {
            //Show URL of article.
        }
        public void showArticleSummary()
        {
            //Show the first few lines of the article. 
        }
    }
}
