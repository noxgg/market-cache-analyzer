using System.Collections.Generic;

namespace noxiousET.cacheAnalyzer
{
    class Items
    {
        private readonly Dictionary<short, ItemRegions> _items;

        public Items()
        {
            _items = new Dictionary<short, ItemRegions>();
        }

        public void Add(short typeId, ItemRegions itemRegions)
        {
            _items[typeId] = itemRegions;
        }

        public bool Contains(short typeId)
        {
            return _items.ContainsKey(typeId);
        }

        public ItemRegions Get(short typeID)
        {
            return _items[typeID];
        }
    }
}
