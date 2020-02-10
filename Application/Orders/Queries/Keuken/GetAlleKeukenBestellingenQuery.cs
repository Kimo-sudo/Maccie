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

            public GetKitchenQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<List<KeukenVm>> Handle(GetAlleKeukenBestellingenQuery request, CancellationToken cancellationToken)
            {
                var alleOrders =
                    await _context.Bestellingen
                        .Where(order => order.KeukenAfgerond == false)
                        .Include(order => order.Producten)
                            .ThenInclude(besteldProduct => besteldProduct.Product)
                        .ToListAsync(cancellationToken);
                var burgersPerOrder = FilterAlleenBurgersPerOrder(alleOrders);
                return burgersPerOrder;

            }


            // Juiste hoeveelheid keukenbestellingen maken
            // En voeg hieraan toe de burger en hoeveel 
            private static List<KeukenVm> FilterAlleenBurgersPerOrder(IReadOnlyList<Order> orders)
            {
                var result = new List<KeukenVm>();
                for (var i = 0; i <= orders.Count - 1; i++)
                {
                    result.Add(new KeukenVm());
                    result[i].OrderId = orders[i].OrderId;

                        var bestelling = orders[i].Producten;
                        result[i].Bestelling = bestelling
                            .GroupBy(g => new Tuple<string, int>(g.Product.ProductName, g.Hoeveelheid))
                            .Select(x => new BurgerMetAantallenDto()
                            {
                                Name = x.Key.Item1,
                                Amount = x.Key.Item2,
                            })
                            .ToList();
                }
                return result;
            }
        }
    }
}