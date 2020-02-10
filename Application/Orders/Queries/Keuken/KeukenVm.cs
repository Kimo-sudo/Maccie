using System.Collections.Generic;

namespace Application.Orders.Queries.Keuken
{
    public class KeukenVm
    {
        public int OrderId { get; set; }
        public List<BurgerMetAantallenDto> Bestelling { get; set; }
        public bool Done { get; set; }
    }
}