using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Orders.Queries.Keuken;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders.Commands.Keuken
{
    public class KeukenServedCommand : IRequest
    {
        public int Id { get; set; }
        public class KeukenServedCommandHandler : IRequestHandler<KeukenServedCommand>
        {
            private readonly IApplicationDbContext _context;
            public KeukenServedCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(KeukenServedCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Bestellingen.FindAsync(request.Id);
                entity.KeukenAfgerond = true;
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}