using System.Collections.Generic;

namespace Application.Orders.Queries.Keuken
{
    public class KitchenVm
    {
        public int OrderId { get; set; }
        public List<BurgerDto> Bestelling { get; set; }
        public bool Done { get; set; }
    }
}