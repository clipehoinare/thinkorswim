using Microsoft.Win32;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Security.Cryptography;
using System.Threading;

namespace Library.ThinkOrSwim.Adapter
{
    class Feed : IRTDUpdateEvent, IEnumerable<Tuple<int, double>>
    {
        readonly string registryKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Tos.RTD\CLSID";
        IRTDServer server;
        Queue queue = new Queue();
        int _count = 0;

        internal Feed(int heartbeatInterval, int timeout)
        {
            var rtd = Type.GetTypeFromCLSID(new Guid(Registry.GetValue(registryKey, "", null).ToString()));
            this.server = (IRTDServer)Activator.CreateInstance(rtd);
            this.HeartbeatInterval = heartbeatInterval;
            this.queue.Timeout = timeout;
            this.server.ServerStart(this);
        }

        internal void Stop()
        {
            this.server.ServerTerminate();
        }

        internal void Add(int id, string symbol, string type)
        {
            var objects = new object[] { type, symbol };

            this.server.ConnectData(id, objects, true);
            _count++;
        }

        internal void Remove(int id)
        {
            this.server.DisconnectData(id);
            _count--;
        }

        public bool TryTake(out Tuple<int, double> tuple)
        {
            bool succesful;

            succesful = this.queue.TryTake(out tuple);

            return succesful;
        }
        public int CurrentCount
        {
            get { return _count; }
        }
        internal bool CheckHeartbeat()
        {
            long beat = this.server.Heartbeat();

            return (beat > 0);
        }

        public int HeartbeatInterval
        {
            get; set;
        }

        public void Disconnect()
        {
            this.queue.Disconnect();
        }

        public void UpdateNotify()
        {
            var refresh = server.RefreshData(_count);
            if (refresh.Length > 0)
            {
                for (int i = 0; i < refresh.Length / 2; i++)
                {
                    var id = (int)refresh[0, i];
                    double value2;
                    var converted = double.TryParse(refresh[1, i].ToString(), out value2);
                    if (converted)
                    {
                        this.queue.Push(new Tuple<int, double>(id, value2));
                    }
                }
            }
        }

        public IEnumerator<Tuple<int, double>> GetEnumerator()
        {
            return this.queue;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.queue;
        }
    }
}
