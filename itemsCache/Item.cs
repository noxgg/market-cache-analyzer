using System.Collections.Generic;

namespace noxiousET.marketDataAnalyzer.itemsCache
{
    class Item
    {
        public List<MarketOrder> SellOrders { set; get; }
        public List<MarketOrder> BuyOrders { set; get; }
        public List<PriceHistoryEntry> PriceHistory { set; get; }
    }
}