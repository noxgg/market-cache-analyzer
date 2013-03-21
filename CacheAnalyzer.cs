using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EveCacheParser;

namespace noxiousET.cacheAnalyzer
{
    class CacheAnalyzer
    {
        private class MarketOrder
        {
            private double _price;
            private double _volRemaining;
            private long _orderID;
            private DateTime _issueDate;
            private int _typeID;
            private int _volEntered;
            private int _minVolume;
            private int _stationID;
            private int _regionID;
            private int _solarSystemID;
            private int _jumps;
            private short _range;
            private short _duration;
            private bool _bid;


            public MarketOrder(Dictionary<object, object> order)
            {
                _price = (double)order["price"];
                _volRemaining = (double)order["volRemaining"];
                _orderID = (long)order["orderID"];
                _issueDate = new DateTime((long)order["issueDate"]);
                _typeID = (int)order["typeID"];
                _volEntered = (int)order["volEntered"];
                _minVolume = (int)order["minVolume"];
                _stationID = (int)order["stationID"];
                _regionID = (int)order["regionID"];
                _solarSystemID = (int)order["solarSystemID"];
                _jumps = (int)order["jumps"];
                _range = (short)order["range"];
                _duration = (short)order["duration"];
                _bid = (bool)order["bid"];
            }

            public bool isBid
            {
                get { return _bid; }
            }
        }

        private FileInfo[] _machoNetFiles;

        public CacheAnalyzer()
        {
            UpdateFileList();
        }

        public void GetMarketOrders()
        {
            Parser.SetIncludeMethodsFilter("GetOrders");
            FileInfo[] cachedFiles = Parser.GetMachoNetCachedFiles();

            foreach (FileInfo cachedFile in cachedFiles)
            {
                KeyValuePair<object, object> result = Parser.Parse(cachedFile);
                var key = (List<object>) ((Tuple<object>) result.Key).Item1;
                long regionID = (long) key[2];
                short typeID = (short) key[3];
                var value = (List<object>) ((Dictionary<object, object>) result.Value)["lret"];
                var orders = value.Cast<List<object>>().SelectMany(
                    obj => obj.Cast<Dictionary<object, object>>(), (obj, order) => new MarketOrder(order)).ToList();

                var sellOrders = orders.Where(order => !order.isBid).ToList();
                var buyOrders = orders.Where(order => order.isBid).ToList();
            }
        }

        public void GetPriceHistory()
        {
            
        }

        public void UpdateFileList()
        {
            _machoNetFiles = EveCacheParser.Parser.GetMachoNetCachedFiles();
        }

        public void ProcessCacheData()
        {
            GetMarketOrders();
        }
    }
}
