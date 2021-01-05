using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ThinkOrSwim.Adapter
{
    class Queue : IEnumerator, IEnumerator<Tuple<int, double>>
    {
        public int Timeout { get; set; }  

        BlockingCollection<Tuple<int, double>> bc = new BlockingCollection<Tuple<int, double>>(new ConcurrentQueue<Tuple<int, double>>());
        Tuple<int, double> current;

        internal Queue()
        {
            
        }

        internal void Disconnect()
        {
            this.bc.CompleteAdding();
        }

        internal void Push(Tuple<int, double> quote)
        {
            this.bc.Add(quote);
        }

        public Tuple<int, double> Current
        {
            get
            {
                return this.current;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return this.current;
            }
        }

        public void Dispose()
        {
            this.bc.Dispose();
        }

        public bool MoveNext()
        {
            if (this.bc.IsCompleted)
            {
                return false;
            }
            this.current = this.bc.Take();
            return true;
        }

        public bool TryTake(out Tuple<int, double> tuple)
        {
            bool succesful;

            succesful = this.bc.TryTake(out tuple, timeout: TimeSpan.FromSeconds(Timeout));

            if (succesful)
                current = tuple;

            return succesful;
        }

        public void Reset()
        {
     
        }
    }
}
