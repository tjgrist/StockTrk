# StockTrk
One week Stock Tracker project with Yahoo Finance API integration

This is a console application built in a week for a solo project at DevCodeCamp. 
The application offers user functionality for tracking stocks of their choosing, including: 

1. User sign in (using Regex)

2. The user then adds stocks to their tracked Portfolio. A list of sample stocks are included, e.g. AAPL, GOOGL, etc.

3. The user then is prompted to include a number of stock quotes they'd like to see of each stock in their portfolio.
These quotes include things such as Earnings per share, ask/buy price, %change real-time, volume, etc.

4. The program then prints out each stock and clarifies which quote (open price, 52-week high, etc.) belongs
to which figure. 

5. The user is then given six options: 
-Change Stocks in their portfolio either by replacing certain stocks or adding more. 
-Change quotes in their portfolio either by replacing certain quotes or adding more. 
-View their current/updated portfolio.
-Download a .csv file of their portfolio to their local machine (using WebClient). 
-Search Reddit (using RedditSharp API integration)
for trending articles about any of the user's tracked stocks. The user can also launch any
of the articles to a browser from the application by entering a command.
The user also has the option to search Reddit more generally for treding stockMarket topics.
-The user can also add a price alert for any of their stocks, at which they'll be notified if the stock 
dips below the input price.

6. The last option is simply to quit the program.
