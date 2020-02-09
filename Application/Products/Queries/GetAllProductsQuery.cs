using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Queries
{
    public class GetAllProductsQuery : IRequest<List<Product>>
    {

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
        {
            private readonly IApplicationDbContext _context;

            public GetAllProductsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {

                var entities = await _context.Producten.Include(x => x.Categorie).ToListAsync(cancellationToken);
                return entities;
            }
        }
    }
}