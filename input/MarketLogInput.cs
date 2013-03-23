using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using noxiousET.marketDataAnalyzer.itemsCache;

namespace noxiousET.marketDataAnalyzer.input
{
    class MarketLogInput
    {

        private readonly Regions _regions;
        private readonly OwnedOrders _ownedOrders;

        public MarketLogInput(Regions regions, OwnedOrders ownedOrders)
        {
            _regions = regions;
            _ownedOrders = ownedOrders;
        }

        public void AddFromExport(FileInfo[] logFiles)
        {
            foreach (FileInfo fi in logFiles)
            {
                AddFromExport(fi);
            }
        }

        public Item AddFromExport(FileInfo logFile)
        {
            var input = File.ReadAllLines(logFile.FullName);

            if (!IsExportedOrder(input))
            {
                if (IsExportedOwnedOrders(input))
                {
                    AddOwnedOrders(input);
                }

                return null;
            }

            //Skip the header row of the input file when converting the data
            var marketOrders = input.Select(line => line.Split(',')).Select(columns => new MarketOrder(columns)).Skip(1).ToList();
            var region = marketOrders.First().RegionID;
            var typeID = marketOrders.First().TypeID;

            var item = GetItem(typeID, region);

            item.BuyOrders = marketOrders.Where(order => order.Bid).ToList();
            item.SellOrders = marketOrders.Where(order => !order.Bid).ToList();

            return item;
        }

        private void AddOwnedOrders(IEnumerable<string> lines)
        {
            var ownedOrders = lines.Select(line => line.Split(',')).Select(columns => new OwnedOrder(columns)).Skip(1).ToList();

            foreach (var oo in ownedOrders)
            {
                _ownedOrders.Add(oo);
            }
        }

        private bool IsExportedOwnedOrders(IList<string> lines)
        {
            return lines[0].Split(',').Length == 23;
        }

        private Boolean IsExportedOrder(IList<string> lines)
        {
            return lines[0].Split(',').Length == 15;
        }

        private Item GetItem(short typeID, int region)
        {
            if (!_regions.ContainsKey(region))
            {
                _regions.Add(region, new RegionalItemCache());
            }

            var regionalCache = _regions[region];

            if (!regionalCache.ContainsKey(typeID))
            {
                regionalCache.Add(typeID, new Item());
            }
            return regionalCache[typeID];
        }
    }
}
