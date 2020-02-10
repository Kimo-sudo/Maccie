using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Orders.Commands.Kassa
{
    public class AddBestellingCommand : IRequest
    {
        public int Id { get; set; }

        public class AddBestellingCommandHandler : IRequestHandler<AddBestellingCommand>
        {
            private readonly IApplicationDbContext _context;

            public AddBestellingCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public Task<Unit> Handle(AddBestellingCommand request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }


    }
}