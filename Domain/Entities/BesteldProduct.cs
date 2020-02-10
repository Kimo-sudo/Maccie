using Domain.Common;

namespace Domain.Entities
{
    public class BesteldProduct
    {
        public BesteldProduct()
        {
            Product = new Product();
        }
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Hoeveelheid { get; set; }
    }
}