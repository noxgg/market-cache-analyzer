using System.Collections.Generic;

namespace noxiousET.cacheAnalyzer
{
    class ItemData
    {
        public List<MarketOrder> SellOrders { set; get; }
        public List<MarketOrder> BuyOrders { set; get; }
        public List<PriceHistoryEntry> PriceHistory { set; get; }
    }
}