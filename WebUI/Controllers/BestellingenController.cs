using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Orders.Commands.Kassa;
using Application.Orders.Queries.Kassa;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class BestellingenController : ApiController
    {
        [HttpGet]

        public async Task<List<Order>> GetAll()
        {
            return await Mediator.Send(new GetAllOrdersQuery());
        }

        [HttpPost]

        public async Task<ActionResult<Unit>> Post(AddBestellingCommand command)
        {
           return await Mediator.Send(command);
        }
    }
}