using System;
using System.Collections.Generic;

namespace noxiousET.cacheAnalyzer
{
    class MarketOrder
    {
        public readonly double Price;
        public readonly double VolRemaining;
        public readonly long OrderID;
        public readonly DateTime IssueDate;
        public readonly int TypeID;
        public readonly int VolEntered;
        public readonly int MinVolume;
        public readonly int StationID;
        public readonly int RegionID;
        public readonly int SolarSystemID;
        public readonly int Jumps;
        public readonly short Range;
        public readonly short Duration;
        public readonly bool Bid;


        public MarketOrder(Dictionary<object, object> order)
        {
            Price = (double)order["price"];
            VolRemaining = (double)order["volRemaining"];
            OrderID = (long)order["orderID"];
            IssueDate = new DateTime((long)order["issueDate"]);
            TypeID = (int)order["typeID"];
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
    }
}