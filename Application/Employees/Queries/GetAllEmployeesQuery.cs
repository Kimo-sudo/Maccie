using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Employees.Queries
{
    public class GetAllEmployeesQuery : IRequest<List<Employee>>
    {
        public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<Employee>>
        {
            private readonly IApplicationDbContext _context;

            public GetAllEmployeeQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<List<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
            {

                var entities = await _context.Employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToListAsync(cancellationToken);
                return entities;
            }
        }
    }
}