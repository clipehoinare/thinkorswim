using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library.ThinkOrSwim.Adapter
{
    public enum DataType
    {
         Ask = 1,
         Bid = 2,
         Close = 4,
         Delta = 8,
         Gamma = 16,
         High = 32,
         Last = 64,
         Low = 128,
         Impl_vol = 256,
         Mark = 512,
         Open = 1024,
         Strike = 2048,
         Theta = 4096,
         Vega = 8192,
         Expiration_day=16384
    }

    public class Client : IDisposable
    {
        Feed feed;
        public Quotes Quotes { get; set; }
        public Client() : this(10, 30)
        {
        }
        public Client(int timeout) : this(10, timeout)
        {
        }
        public Client(int heartbeatInterval, int timeout)
        {
            this.feed = new Feed(heartbeatInterval, timeout);
        }
        public bool IsClientActive()
        {
            var active = feed.CheckHeartbeat();

            return active;
        }
        public void Add(Quote quote)
        {
            Quotes.AddQuote(quote);
            this.feed.Add(quote.Id, quote.Symbol, quote.DataType);
        }
        public void Remove(int id)
        {
            Quotes.DelQuote(id);
            this.feed.Remove(id);
        }
        public int CurrentCount
        {
            get { return this.feed.CurrentCount; }
        }
        public bool GetOneQuote(out Quote quote, out Tuple<int, double> tuple)
        {
            bool succesful;

            succesful = this.feed.TryTake(out tuple);

            if (succesful)
            {
                quote = Quotes.GetQuote(tuple);
            }
            else
            {
                quote = null;
            }    

            return succesful;
        }
        //public IEnumerable<Tuple<int, double>> Quotes()
        //{
        //    return this.feed;
        //}
        public void Dispose()
        {
            this.feed.Stop();
        }
    }
}
