using System.Collections.Generic;

namespace noxiousET.marketDataAnalyzer.itemsCache
{
    class OwnedOrders: Dictionary<short, Dictionary<long, OwnedOrder>>
    {
        
        public void Add(OwnedOrder ownedOrder)
        {
            var typeID = ownedOrder.TypeID;
            if (!ContainsKey(typeID))
            {
                this[typeID] = new Dictionary<long, OwnedOrder>();
            }

            this[typeID][ownedOrder.OrderID] = ownedOrder;
        }
    }

}
