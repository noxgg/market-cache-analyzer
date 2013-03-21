using System.Collections.Generic;

namespace noxiousET.cacheAnalyzer
{
    class ItemData
    {
        public readonly Dictionary<short, RegionalItemData> Items;

        public ItemData()
        {
            Items = new Dictionary<short, RegionalItemData>();
        }

        public void Add(short typeId, RegionalItemData regionalItemData)
        {
            Items[typeId] = regionalItemData;
        }

        public bool Contains(short typeId)
        {
            return Items.ContainsKey(typeId);
        }

        public RegionalItemData Get(short typeID)
        {
            return Items[typeID];
        }
    }
}
