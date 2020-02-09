using System.Collections.Generic;
using Domain.Entities;

namespace Application.Orders.Queries.Keuken
{
 
    // TODO: Timer toevoegen 

    public class KeukenBestellingVm
    {
        public KeukenBestellingVm()
        {
            Burgers = new List<BesteldProduct>();
        }
        public int OrderId { get; set; }
        public bool Gemaakt { get; set; } = false;
        public List<BesteldProduct> Burgers { get; set; }
    }
}
