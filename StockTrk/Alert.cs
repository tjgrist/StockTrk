using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrk
{
    class Alert
    {
        string alertStock;
        string askPriceAlert;
        
        public string checkAlert(string quote, string symbol)
        {
              if (Convert.ToSingle(quote) < Convert.ToSingle(askPriceAlert) && (symbol == alertStock))
                {
                    return "*ALERT!* Your stock dipped BELOW your set price! It's at: $" + quote
                        + " Your price alert was set to: $" + askPriceAlert; 
                }
                else
                {
                    return "Asking: $" + quote; 
                }            
        }
        public string AskPriceAlert
        {
            get { return askPriceAlert; }
            set { askPriceAlert = value; }
        }
        public string AlertStock
        {
            get { return alertStock; }
            set { alertStock = value; }
        }
    }
}
