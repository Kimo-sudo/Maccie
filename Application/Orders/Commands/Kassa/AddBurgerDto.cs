using System.Collections.Generic;
using Application.Orders.Queries.Keuken;
using Domain.Entities;

namespace Application.Orders.Commands.Kassa
{
    public class AddBurgerDto
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}