using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Orders.Commands.Service;
using Application.Orders.Queries.Keuken;
using Application.Orders.Queries.Service;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ServiceController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAll()
        {
            return await Mediator.Send(new GetAllServiceBestellingQuery());
        }
    }
}