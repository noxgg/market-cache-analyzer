using System.Collections.Generic;

namespace noxiousET.marketDataAnalyzer.itemsCache
{
    class RegionalItemCache

    {
        private readonly Dictionary<short, Item> _items;

        public RegionalItemCache()
        {
            _items = new Dictionary<short, Item>();
        }

        public void Add(short itemID, Item item)
        {
            _items.Add(itemID, item);
        }

        public bool Contains(short itemID)
        {
            return _items.ContainsKey(itemID);
        }

        public Item Get(short itemID)
        {
            return _items.ContainsKey(itemID) ? _items[itemID] : null;
        }
    }
}