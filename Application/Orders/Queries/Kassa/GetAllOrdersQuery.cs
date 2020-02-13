using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders.Queries.Kassa
{
    public class GetAllOrdersQuery : IRequest<List<Order>>
    {
        public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<Order>>
        {
            private readonly IApplicationDbContext _context;

            public GetAllOrdersQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<List<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
            { 
                return await _context.Bestellingen
                    .Include(x => x.BesteldeProducten)
                    .ThenInclude(x => x.Product)
                    .Include(x => x.Employee)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}