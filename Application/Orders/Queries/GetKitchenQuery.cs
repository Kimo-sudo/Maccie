using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Orders.Queries
{
    public class GetKitchenQuery : IRequest<List<KitchenOrderVm>>
    {


        public class GetKitchenQueryHandler : IRequestHandler<GetKitchenQuery, List<KitchenOrderVm>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetKitchenQueryHandler(IMapper mapper, IApplicationDbContext context)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<List<KitchenOrderVm>> Handle(GetKitchenQuery request, CancellationToken cancellationToken)
            {
                var alleOrders = 
                    await _context.Bestellingen
                        .Include(x => x.BesteldeProducten)
                        .ThenInclude(x => x.Product)
                        .ToListAsync(cancellationToken);

                var orders = FilterOrdersMetBurgers(alleOrders);
                var displayAllBurgers = FilterAlleenBurgersPerOrder(orders);
                return displayAllBurgers;
            }

            // Methods
            private List<KitchenOrderVm> FilterAlleenBurgersPerOrder(List<Order> orders)
            {
                var result = new List<KitchenOrderVm>();
                for (int i = 0; i <= orders.Count - 1; i++)
                {
                    result.Add(new KitchenOrderVm());
                    for (int j = 0; j <= orders[i].BesteldeProducten.Count - 1; j++)
                    {
                        result[i].Burgers.Add(orders[i].BesteldeProducten[j].Product.ProductName);
                    }
                }

                return result;
            }
            private List<Order> FilterOrdersMetBurgers(List<Order> allorders)
            {
                var result = new List<Order>();
                foreach (var order in allorders)
                {
                    foreach (var besteldProduct in order.BesteldeProducten)
                    {
                        if (besteldProduct.Product.CategorieId == 1)
                        {
                            result.Add(order);
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                return result;
            }
        }
    }
}