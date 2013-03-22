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
        public int TypeID { private set; get; }
        public int VolEntered { private set; get; }
        public int MinVolume { private set; get; }
        public int StationID { private set; get; }
        public int RegionID { private set; get; }
        public int SolarSystemID { private set; get; }
        public int Jumps { private set; get; }
        public short Range { private set; get; }
        public short Duration { private set; get; }
        public bool Bid { private set; get; }


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