using System;
using System.Collections.Generic;
using System.Linq;
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
                    Producten =
                    {
                    }
                };
                var besteld = request.Producten.Select(product => new BesteldProduct {Product = _context.Producten.FirstOrDefault(x => x.Id == product.ProductId), Hoeveelheid = product.Amount}).ToList();
                besteld.ForEach(x => entity.Producten.Add(x));

                if (entity.Producten.Count(product => product.Product.CategorieId == 1) >= 1 )
                {
                    entity.KeukenAfgerond = false;
                }
                if (entity.Producten.Count(product => product.Product.CategorieId == 3) >= 1)
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