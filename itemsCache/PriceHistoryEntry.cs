using System;
using System.Collections.Generic;

namespace noxiousET.marketDataAnalyzer.itemsCache
{
    class PriceHistoryEntry
    {
        public DateTime HistoryDate { private set; get; }
        public double LowPrice { private set; get; }
        public double HighPrice { private set; get; }
        public double AvgPrice { private set; get; }
        public long Volume { private set; get; }
        public int Orders { private set; get; }

        public PriceHistoryEntry(Dictionary<object, object> priceHistory)
        {
            HistoryDate = new DateTime((long)priceHistory["historyDate"]);
            LowPrice = (double) priceHistory["lowPrice"];
            HighPrice = (double) priceHistory["highPrice"];
            AvgPrice = (double) priceHistory["avgPrice"];
            Volume = (long) priceHistory["volume"];
            Orders = (int) priceHistory["orders"];
        }
    }
}
