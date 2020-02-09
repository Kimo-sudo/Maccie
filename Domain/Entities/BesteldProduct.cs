using Domain.Common;

namespace Domain.Entities
{
    public class BesteldProduct
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Hoeveelheid { get; set; }

    }
}