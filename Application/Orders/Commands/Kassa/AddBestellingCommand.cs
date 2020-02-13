using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders.Commands.Kassa
{
    public class AddBestellingCommand : IRequest
    {
        public int Id { get; set; }
        public List<AddBurgerDto> Producten { get; set; }
        public class AddBestellingCommandHandler : IRequestHandler<AddBestellingCommand>
        {
            private readonly IApplicationDbContext _context;

            public AddBestellingCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(AddBestellingCommand request, CancellationToken cancellationToken)
            {
                var entity = new Order
                {
                    OrderDateTime = DateTime.Now,
                    Afgerond = false,
                    KeukenAfgerond = true, 
                    DrankjesAfgerond = true,
                    BesteldeProducten = 
                    {
                    }
                };

                var besteldeProducten = new List<BesteldProduct>();

                foreach (var burgerDto in request.Producten)
                {
                    var b = new BesteldProduct
                    {
                        ProductId = burgerDto.ProductId,
                        Hoeveelheid = burgerDto.Amount
                    };
                    besteldeProducten.Add(b);
                }

                foreach (var besteldProduct in besteldeProducten)
                {
                    var x = await _context.Producten.FirstOrDefaultAsync(product => product.Id == besteldProduct.ProductId,
                        cancellationToken);
                    besteldProduct.Product = x;
                    entity.BesteldeProducten.Add(besteldProduct);
                } 

                if (entity.BesteldeProducten.Count(product => product.Product.CategorieId == 1) != 0)
                {
                    entity.KeukenAfgerond = false;
                }
                if (entity.BesteldeProducten.Count(product => product.Product.CategorieId == 3) != 0)
                {
                    entity.DrankjesAfgerond = false;
                }

                _context.Bestellingen.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;

            }
        }


    }
}