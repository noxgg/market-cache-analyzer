using System.Collections.Generic;

namespace noxiousET.marketDataAnalyzer.itemsCache
{
    class Regions
    {
        private readonly Dictionary<long, RegionalItemCache> _regions;

        public Regions()
        {
            _regions = new Dictionary<long, RegionalItemCache>();
        }

        public void Add(long regionID, RegionalItemCache regionalItemCache)
        {
            _regions[regionID] = regionalItemCache;
        }

        public bool Contains(long regionID)
        {
            return _regions.ContainsKey(regionID);
        }

        public RegionalItemCache Get(long regionID)
        {
            return _regions[regionID];
        }

        public Item GetItemForRegion(short itemID, long regionID)
        {
            if (_regions.ContainsKey(regionID))
            {
                return _regions[regionID].Get(itemID);
            }
            return null;
        }
    }
}
