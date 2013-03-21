using System.Collections.Generic;

namespace noxiousET.cacheAnalyzer
{
    class ItemRegions

    {
        private readonly Dictionary<long, ItemData> _regions;

        public ItemRegions()
        {
            _regions = new Dictionary<long, ItemData>();
        }

        public void Add(long regionID, ItemData itemData)
        {
            _regions.Add(regionID, itemData);
        }

        public bool Contains(long regionID)
        {
            return _regions.ContainsKey(regionID);
        }

        public ItemData Get(long regionID)
        {
            return _regions[regionID];
        }
    }
}