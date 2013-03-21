using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EveCacheParser;

namespace noxiousET.cacheAnalyzer
{
    class CacheAnalyzer
    {
        private readonly Items _items;
        public CacheAnalyzer()
        {
            _items = new Items();
        }

        public void GetMarketData()
        {
            Parser.SetIncludeMethodsFilter("GetOrders", "GetOldPriceHistory", "GetNewPriceHistory");
            FileInfo[] cachedFiles = Parser.GetMachoNetCachedFiles();

            foreach (FileInfo cachedFile in cachedFiles)
            {
                KeyValuePair<object, object> cacheResult = Parser.Parse(cachedFile);
                var cacheResultKey = (List<object>)((Tuple<object>)cacheResult.Key).Item1;
                var resultType = (string) cacheResultKey[1];
                var typeID = (short)cacheResultKey[3];
                var regionID = (long) cacheResultKey[2];
                var regionalItemData = GetItemsRegionalData(typeID);
                var cacheResultValue = (List<object>)((Dictionary<object, object>)cacheResult.Value)["lret"];

                if (resultType.Equals("GetOrders"))
                {
                    GetOrderData(regionID, regionalItemData, cacheResultValue);
                }
                else
                {
                    GetPriceHistory(regionID, regionalItemData, cacheResultValue);
                }
            }
        }

        private void GetOrderData(long regionID, ItemRegions itemRegions, IEnumerable<object> value)
        {
            var orders = value.Cast<List<object>>().SelectMany(
                obj => obj.Cast<Dictionary<object, object>>(), (obj, order) => new MarketOrder(order)).ToList();

            var itemData = new ItemData
            {
                SellOrders = orders.Where(order => !order.Bid).ToList(),
                BuyOrders = orders.Where(order => order.Bid).ToList()
            };

            if (itemRegions.Contains(regionID))
            {
                var existingRegionalData = itemRegions.Get(regionID);
                existingRegionalData.SellOrders = itemData.SellOrders;
                existingRegionalData.BuyOrders = itemData.BuyOrders;
            }
            else
            {
                itemRegions.Add(regionID, itemData);
            }
        }

        private void GetPriceHistory(long regionID, ItemRegions itemRegions, IEnumerable<object> value)
        {
            var itemData = new ItemData
                {
                    PriceHistory = value.Cast<Dictionary<object, object>>().Select(
                        entry => new PriceHistoryEntry(entry)).ToList()
                };

            if (itemRegions.Contains(regionID))
            {
                itemRegions.Get(regionID).PriceHistory = itemData.PriceHistory;
            }
            else
            {
                itemRegions.Add(regionID, itemData);
            }
        }

        private ItemRegions GetItemsRegionalData(short typeID)
        {

            if (!_items.Contains(typeID))
            {
                _items.Add(typeID, new ItemRegions());
            }

            return _items.Get(typeID);

        }
    }
}
