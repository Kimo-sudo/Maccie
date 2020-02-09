using System;
using System.Collections.Generic;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Orders.Queries
{
    public class OrderKitchenDto : IMapFrom<Order>
    {
        public int Id { get; set; }
        public List<BesteldProduct> BesteldeProducten { get; set; }
        
    }
}