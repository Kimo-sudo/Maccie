using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Employees.Commands
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int PhoneNumber { get; set; }

        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateEmployeeCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }


            public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var entity = new Employee()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber
                };

                _context.Employees.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return entity.EmployeeId;
            }
        }
    }
}