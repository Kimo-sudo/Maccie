using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class Order : OrderEntity
    {
        public Order()
        {
            Producten = new List<BesteldProduct>();
        }
        public int OrderId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public List<BesteldProduct> Producten { get; set; }
        public bool Afgerond { get; set; }
        public bool KeukenAfgerond { get; set; }
        public bool DrankjesAfgerond { get; set; }
    }
}