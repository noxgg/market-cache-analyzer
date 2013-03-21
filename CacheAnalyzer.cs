using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EveCacheParser;

namespace noxiousET.cacheAnalyzer
{
    class CacheAnalyzer
    {

        private FileInfo[] _machoNetFiles;
        private readonly ItemData _itemData;
        public CacheAnalyzer()
        {
            _itemData = new ItemData();
        }

        public void GetMarketOrders()
        {
            Parser.SetIncludeMethodsFilter("GetOrders");
            FileInfo[] cachedFiles = Parser.GetMachoNetCachedFiles();

            foreach (FileInfo cachedFile in cachedFiles)
            {
                KeyValuePair<object, object> result = Parser.Parse(cachedFile);
                var key = (List<object>)((Tuple<object>)result.Key).Item1;
                var typeID = (short)key[3];

                if (!_itemData.Contains(typeID))
                {
                    _itemData.Add(typeID, new RegionalItemData());
                }

                var regionID = (long) key[2];
                var regionalItemData = _itemData.Get(typeID);
                if (regionalItemData.Contains(regionID))
                {
                    return;
                }


                var value = (List<object>) ((Dictionary<object, object>) result.Value)["lret"];
                var orders = value.Cast<List<object>>().SelectMany(
                    obj => obj.Cast<Dictionary<object, object>>(), (obj, order) => new MarketOrder(order)).ToList();

                var marketOrders = new MarketOrders
                    {
                        SellOrders = orders.Where(order => !order.Bid).ToList(),
                        BuyOrders = orders.Where(order => order.Bid).ToList()
                    };

                regionalItemData.Add(regionID, marketOrders);
            }
        }

        public void GetPriceHistory()
        {
            
        }
    }
}
