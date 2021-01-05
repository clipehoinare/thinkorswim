using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ThinkOrSwim.Adapter
{
    public class Quote
    {
        double _value;

        public int Id { get; protected set; }
        public string Symbol { get; protected set; }
        public string DataType { get; protected set; }
        public int CounterId { get; protected set; }
        public double Value { get { return _value; } set { _value = value; Updated = true; } }
        public bool Updated { get; set; }

        internal Quote(int id, string symbol, string dataType, int counterId, double value)
        {
            this.Id = id;
            this.Symbol = symbol;
            this.DataType = dataType;
            this.CounterId = counterId;
            this.Value = value;
            this.Updated = false;
        }
        public Quote(int id, string symbol, string dataType, int counterId)
        {
            this.Id = id;
            this.Symbol = symbol;
            this.DataType = dataType;
            this.CounterId = counterId;
        }
    }
}
