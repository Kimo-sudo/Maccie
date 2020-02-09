using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Products.Commands
{
    public class CreateProductCommand : IRequest<int>
    {

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public double Prijs { get; set; }
        public string ProductName { get; set; }

        public bool Actief { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var entity = new Product()
                {
                    CategorieId = request.CategoryId,
                    Id = request.ProductId,
                    Prijs = request.Prijs,
                    ProductName = request.ProductName,
                    Actief = request.Actief
                };

                _context.Producten.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return entity.Id;
                }
        }
    }
}

