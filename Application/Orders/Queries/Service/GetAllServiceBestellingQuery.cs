using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders.Queries.Service
{
    public class GetAllServiceBestellingQuery : IRequest<List<Order>>
    {
        
        public class GetAllServiceBestellingQueryHandler : IRequestHandler<GetAllServiceBestellingQuery, List<Order>>
        {
            private readonly IApplicationDbContext _context;

            public GetAllServiceBestellingQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<List<Order>> Handle(GetAllServiceBestellingQuery request, CancellationToken cancellationToken)
            {
                var alleOrders = await _context.Bestellingen
                    .Where(x => x.KeukenAfgerond == true && x.DrankjesAfgerond == true)
                    .Include(order => order.BesteldeProducten)
                    .ThenInclude(Besteld => Besteld.Product)
                    .ToListAsync(cancellationToken);

                return alleOrders;
            }
        }
    }
}