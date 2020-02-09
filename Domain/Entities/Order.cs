using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class Order : CashierEntity
    {
        public Order()
        {
            BesteldeProducten = new List<BesteldProduct>();
        }
        public int OrderId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public List<BesteldProduct> BesteldeProducten { get; private set; }
    }
}