using System;
using System.Collections.Generic;

namespace noxiousET.cacheAnalyzer
{
    class PriceHistoryEntry
    {
        public readonly DateTime HistoryDate;
        public readonly double LowPrice;
        public readonly double HighPrice;
        public readonly double AvgPrice;
        public readonly long Volume;
        public readonly int Orders;

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
