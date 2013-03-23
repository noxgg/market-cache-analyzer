using System;

namespace noxiousET.marketDataAnalyzer.itemsCache
{
    class OwnedOrder
    {
        public long OrderID { private set; get; }
        public short TypeID { private set; get; }
        public int CharID { private set; get; }
        
        private const short MyOrdersColumnOrderId = 0;
        private const short MyOrdersColumnTypeId = 1;
        private const short MyOrdersColumnCharacterId = 2;
        private const short MyOrdersColumnCharacterName = 3;
        private const short MyOrdersColumnRegionId = 4;
        private const short MyOrdersColumnRegionName = 5;
        private const short MyOrdersColumnStationId = 6;
        private const short MyOrdersColumnStationName = 7;
        private const short MyOrdersColumnRange = 8;
        private const short MyOrdersColumnIsBuyOrder = 9;
        private const short MyOrdersColumnPrice = 10;
        private const short MyOrdersColumnVolumeEntered = 11;
        private const short MyOrdersColumnVolumeRemaining = 12;
        private const short MyOrdersColumnIssueDate = 13;
        private const short MyOrdersColumnOrderState = 14;
        private const short MyOrdersColumnMinimumVolume = 15;
        private const short MyOrdersColumnAccountId = 16;
        private const short MyOrdersColumnDuration = 17;
        private const short MyOrdersColumnIsCorp = 18;
        private const short MyOrdersColumnSolarSystemid = 19;
        private const short MyOrdersColumnSolarSystemName = 20;
        private const short MyOrdersColumnEscrow = 21;

        public OwnedOrder(string[] ownedOrder)
        {
            OrderID = Convert.ToInt64(ownedOrder[MyOrdersColumnOrderId]);
            TypeID = Convert.ToInt16(ownedOrder[MyOrdersColumnTypeId]);
            CharID = Convert.ToInt32(ownedOrder[MyOrdersColumnCharacterId]);
        }
    }
}
