using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{

        public interface IApplicationDbContext
        {
            //
            DbSet<Employee> Employees { get; set; }
            DbSet<Order> Bestellingen { get; set; }
            DbSet<Categorie> Categories { get; set; }
            DbSet<Product> Producten { get; set; }
            DbSet<BesteldProduct> BesteldeProducten { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
    
}