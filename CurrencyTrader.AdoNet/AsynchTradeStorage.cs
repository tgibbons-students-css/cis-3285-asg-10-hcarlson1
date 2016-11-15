using CurrencyTrader.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyTrader.AdoNet
{
    public class AsynchTradeStorage : ITradeStorage
    {
        AdoNetTradeStorage SynchTradeStorage;
        private readonly ILogger logger;

        public AsynchTradeStorage(ILogger logger) {

            SynchTradeStorage = new AdoNetTradeStorage(logger);
            this.logger = logger;

        }
        
        public void Persist(IEnumerable<TradeRecord> trades)
        {
            Task.Run(() => SynchTradeStorage.Persist(trades));
        }
    }
}
