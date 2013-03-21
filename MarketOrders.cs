using System.Collections.Generic;
using noxiousET.cacheAnalyzer;

namespace noxiousET.cacheAnalyzer
{
    class MarketOrders
    {
        public List<MarketOrder> SellOrders { set; get; }
        public List<MarketOrder> BuyOrders { set; get; }
    }
}