using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain.Entities;

namespace Application.Orders.Queries
{
    // TODO: Order ID toevoegen
    // TODO: Timer toevoegen 

    public class KitchenOrderVm
    {
        public KitchenOrderVm()
        {
            Burgers = new List<string>();
        }
        public List<string> Burgers { get; set; }
        public bool Gemaakt { get; set; } = false;
    }
}
