using System.Collections.Generic;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Orders.Queries.Keuken
{
    public class OrderKitchenDto : IMapFrom<Order>
    {
        public int Id { get; set; }
        public List<BesteldProduct> BesteldeProducten { get; set; }
    }
}