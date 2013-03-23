using System.Collections.Generic;

namespace noxiousET.marketDataAnalyzer.itemsCache
{
    class Regions : Dictionary<int, RegionalItemCache>
    {
        public Item GetItemForRegion(short itemID, int regionID)
        {
            return ContainsKey(regionID) ? this[regionID][itemID] : null;
        }
    }
}
