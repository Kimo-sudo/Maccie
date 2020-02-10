using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders.Queries.Keuken
{
    public class GetAlleKeukenBestellingenQuery : IRequest<List<KeukenVm>>
    {
        public class GetKitchenQueryHandler : IRequestHandler<GetAlleKeukenBestellingenQuery, List<KeukenVm>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetKitchenQueryHandler(IMapper mapper, IApplicationDbContext context)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<List<KeukenVm>> Handle(GetAlleKeukenBestellingenQuery request, CancellationToken cancellationToken)
            {
                var alleOrders = 
                    await _context.Bestellingen
                        .Where(x => x.KeukenAfgerond == false)
                        .Include(x => x.BesteldeProducten)
                        .ThenInclude(x => x.Product)
                        .ToListAsync(cancellationToken);
                var orders = FilterOrdersMetBurgers(alleOrders);
                var burgersPerOrder = FilterAlleenBurgersPerOrder(orders);

                return burgersPerOrder;
            }


            // Juiste hoeveelheid keukenbestellingen maken
            // En voeg hieraan toe de burger en hoeveel 
            private List<KeukenVm> FilterAlleenBurgersPerOrder(List<Order> orders)
            {
                var result = new List<KeukenVm>();


                for (int i = 0; i <= orders.Count - 1; i++)
                {
                    result.Add(new KeukenVm());
                    for (int j = 0; j <= orders[i].BesteldeProducten.Count - 1; j++)
                    {
                        result[i].OrderId = orders[i].OrderId;

                        var bestelling = orders[i].BesteldeProducten;
                        result[i].Bestelling = bestelling
                            .GroupBy(g => new Tuple<string, int>(g.Product.ProductName, g.Hoeveelheid))
                            .Select(x => new BurgerMetAantallenDto()
                            {
                                Name = x.Key.Item1,
                                Amount = x.Key.Item2,
                            })
                            .ToList();
                    }
                }

                return result;
            }

            // Bestelling bevat burger? 
            private List<Order> FilterOrdersMetBurgers(List<Order> alleorders)
            {
                var result = new List<Order>();
                foreach (var order in alleorders)
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