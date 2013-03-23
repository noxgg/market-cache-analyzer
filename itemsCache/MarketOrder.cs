using System;
using System.Collections.Generic;

namespace noxiousET.marketDataAnalyzer.itemsCache
{
    class MarketOrder
    {
        public double Price { private set; get; }
        public double VolRemaining { private set; get; }
        public long OrderID { private set; get; }
        public DateTime IssueDate { private set; get; }
        public short TypeID { private set; get; }
        public int VolEntered { private set; get; }
        public int MinVolume { private set; get; }
        public int StationID { private set; get; }
        public int RegionID { private set; get; }
        public int SolarSystemID { private set; get; }
        public int Jumps { private set; get; }
        public short Range { private set; get; }
        public short Duration { private set; get; }
        public bool Bid { private set; get; }

        private const short ColumnPrice = 0;
        private const short ColumnVolumeRemaining = 1;
        private const short ColumnTypeId = 2;
        private const short ColumnRange = 3;
        private const short ColumnOrderId = 4;
        private const short ColumnVolumeEntered = 5;
        private const short ColumnMinimumVolume = 6;
        private const short ColumnIsBuyOrder = 7;
        private const short ColumnIssueDate = 8;
        private const short ColumnDuration = 9;
        private const short ColumnStationId = 10;
        private const short ColumnRegionId = 11;
        private const short ColumnSolarSystemId = 12;
        private const short ColumnJumps = 13;


        public MarketOrder(Dictionary<object, object> order)
        {
            Price = (double)order["price"];
            VolRemaining = (double)order["volRemaining"];
            OrderID = (long)order["orderID"];
            IssueDate = new DateTime((long)order["issueDate"]);
            TypeID = (short)order["typeID"];
            VolEntered = (int)order["volEntered"];
            MinVolume = (int)order["minVolume"];
            StationID = (int)order["stationID"];
            RegionID = (int)order["regionID"];
            SolarSystemID = (int)order["solarSystemID"];
            Jumps = (int)order["jumps"];
            Range = (short)order["range"];
            Duration = (short)order["duration"];
            Bid = (bool)order["bid"];
        }

        public MarketOrder(String[] order)
        {
            Price = Convert.ToDouble(order[ColumnPrice]);
            VolRemaining = Convert.ToDouble(order[ColumnVolumeRemaining]);
            OrderID = Convert.ToInt32(order[ColumnOrderId]);
            IssueDate = new DateTime(Convert.ToInt64(order[ColumnIssueDate]));
            TypeID = Convert.ToInt16(order[ColumnTypeId]);
            VolEntered = Convert.ToInt32(order[ColumnVolumeEntered]);
            MinVolume = Convert.ToInt32(order[ColumnMinimumVolume]);
            StationID = Convert.ToInt32(order[ColumnStationId]);
            RegionID = Convert.ToInt32(order[ColumnRegionId]);
            SolarSystemID = Convert.ToInt32(order[ColumnSolarSystemId]);
            Jumps = Convert.ToInt32(order[ColumnJumps]);
            Range = Convert.ToInt16(order[ColumnRange]);
            Duration = Convert.ToInt16(order[ColumnDuration]);
            Bid = Convert.ToBoolean(order[ColumnIsBuyOrder]);
        }
    }
}