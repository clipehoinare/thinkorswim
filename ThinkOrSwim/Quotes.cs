using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ThinkOrSwim.Adapter
{

    public class Quotes
    {
        public ConcurrentDictionary<Int64, Quote> QuoteDict = new ConcurrentDictionary<Int64, Quote>();

        public void AddQuote(Quote quote)
        {
            this.QuoteDict[quote.Id] = quote;
        }
        public Quote GetQuote(Tuple<int, double> tuple)
        {
            this.QuoteDict.TryGetValue(tuple.Item1, out var quote);
            if (quote != null)
            {
                quote.Value = tuple.Item2;
                quote.Updated = true;
            }
            return quote;
        }
        public Quote DelQuote(int id)
        {
            this.QuoteDict.TryRemove(id, out Quote quote);

            return quote;
        }

    }
}
