using Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Domain.Entities
{
    public class BesteldProduct
    {
        public BesteldProduct()
        {
            
        }
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Order order { get; set; }
        public int Hoeveelheid { get; set; }
    }
}