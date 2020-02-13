using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Orders.Commands.Keuken;
using MediatR;

namespace Application.Orders.Commands.Service
{
    public class ServiceBestellingServedCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public class ServiceBestellingServedCommandHandler : IRequestHandler<ServiceBestellingServedCommand>
        {
            private readonly IApplicationDbContext _context;
            public ServiceBestellingServedCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(ServiceBestellingServedCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Bestellingen.FindAsync(request.Id);
                entity.Afgerond = true;
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}