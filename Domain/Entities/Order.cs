using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class Order : OrderEntity
    {
        public Order()
        {
            BesteldeProducten = new HashSet<BesteldProduct>();
        }
        public int OrderId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public ICollection<BesteldProduct> BesteldeProducten { get; set; }
        public bool Afgerond { get; set; }
        public bool KeukenAfgerond { get; set; }
        public bool DrankjesAfgerond { get; set; }
        public bool FrietAfgerond { get; set; }
    }
}