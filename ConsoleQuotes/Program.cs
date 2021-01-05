using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ThinkOrSwim.Adapter;

namespace ConsoleQuotes
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client(30);

            //client.StockReceived += OnStockReceived;
            //client.QuoteReceived += OnQuoteReceived;

            //client.AddStockRequest("SPY", "ETF");
            //client.AddStockRequest("SPX", "ETF");
            //client.AddStockRequest("RUT", "IDX");
            //client.AddStockRequest("IWM", "ETF");

            //var topics = controller.PullData();

            client.Dispose();

            //List<QuoteRealTime> quoteRealTimes = new List<QuoteRealTime>();


            //QuoteRealTime quote = null;
            //foreach (var header in topics.QuoteHeaders)
            //{
            //    quote = null;
            //    if (header.Value.Completed)
            //    {
            //       quote = new QuoteRealTime(header.Value.Symbol, header.Value.Symbol);
            //    }
            //    foreach(var detail in topics.Quotes.Where(x => x.Value.Symbol==header.Value.Symbol).Select(c => c.Value))
            //    {
            //        quote.SetValue(detail);
            //    }
            //}
        }

        //private static void OnStockReceived(Controller sender, Quote quote, EventArgs e)
        //{
        //    Console.WriteLine("{0} completed", quote.Symbol);
        //}
        //private static void OnQuoteReceived(Controller sender, Quote quote, EventArgs e)
        //{
        //    Console.WriteLine("{0} {1} {2}: ${3}", quote.Symbol, quote.DataType, quote.CounterId, quote.Value);
        //}
        //private static void PerformForEach(Client client)
        //{
        //    byte maxCount = 7;
        //    byte cnt = 0;

        //    // foreach at the end of the loops will call dispose on the Quotes collection
        //    //foreach (var quote in client.Quotes())
        //    //{
        //    //    Console.WriteLine("{0} {1} {2}: ${3}", quote.Symbol, quote.Type, quote.CounterId, quote.Value);

        //    //    if ((cnt & quote.CounterId) == 0)
        //    //        cnt = (byte)(cnt + quote.CounterId);

        //    //    if (cnt >= maxCount)
        //    //        break;
        //    //}
        //}
        private static void RemoveStockRequest(Client client)
        {
            //client.Remove(1);
        }


    }
}
