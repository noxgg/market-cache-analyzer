using System.Collections.Generic;

namespace noxiousET.cacheAnalyzer
{
    class RegionalItemData
    {
        public Dictionary<long, MarketOrders> Regions;

        public RegionalItemData()
        {
            Regions = new Dictionary<long, MarketOrders>();
        }

        public void Add(long regionID, MarketOrders marketOrders)
        {
            Regions.Add(regionID, marketOrders);
        }

        public bool Contains(long regionID)
        {
            return Regions.ContainsKey(regionID);
        }
    }
}
