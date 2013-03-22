using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EveCacheParser;
using noxiousET.marketDataAnalyzer.itemsCache;

namespace noxiousET.marketDataAnalyzer.input
{
    class EveCacheInput
    {
        private readonly Regions _regions;

        public EveCacheInput()
        {
            _regions = new Regions();
        }

        public void GetEveCacheMarketData()
        {
            Parser.SetIncludeMethodsFilter("GetOrders", "GetOldPriceHistory", "GetNewPriceHistory");
            FileInfo[] cachedFiles = Parser.GetMachoNetCachedFiles();

            foreach (FileInfo cachedFile in cachedFiles)
            {
                var cacheResult = Parser.Parse(cachedFile);
                var cacheResultKey = (List<object>)((Tuple<object>)cacheResult.Key).Item1;
                var resultType = (string) cacheResultKey[1];
                var typeID = (short)cacheResultKey[3];
                var regionID = (long) cacheResultKey[2];
                var regionalItemCache = GetRegionalItemCache(regionID);
                var cacheResultValue = (List<object>)((Dictionary<object, object>)cacheResult.Value)["lret"];
                
                if (!regionalItemCache.Contains(typeID))
                {
                    regionalItemCache.Add(typeID, new Item());
                }
                var itemData = regionalItemCache.Get(typeID);

                if (resultType.Equals("GetOrders"))
                {
                    UpdateOrderData(itemData, cacheResultValue);
                }
                else if (resultType.Equals("GetOldPriceHistory") || resultType.Equals("GetNewPriceHistory"))
                {
                    UpdatePriceHistory(itemData, cacheResultValue);
                }
            }
        }

        private void UpdateOrderData(Item itemData, IEnumerable<object> value)
        {
            var orders = value.Cast<List<object>>().SelectMany(
                obj => obj.Cast<Dictionary<object, object>>(), (obj, order) => new MarketOrder(order)).ToList();

            itemData.SellOrders = orders.Where(order => !order.Bid).ToList();
            itemData.BuyOrders = orders.Where(order => order.Bid).ToList();
        }

        private void UpdatePriceHistory(Item itemData, IEnumerable<object> value)
        {
            itemData.PriceHistory = value.Cast<Dictionary<object, object>>().Select(
                entry => new PriceHistoryEntry(entry)).ToList();
        }

        private RegionalItemCache GetRegionalItemCache(long regionID)
        {
            if (!_regions.Contains(regionID))
            {
                _regions.Add(regionID, new RegionalItemCache());
            }

            return _regions.Get(regionID);
        }
    }
}
