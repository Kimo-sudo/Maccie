using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Orders.Commands.Keuken;
using Application.Orders.Queries;
using Application.Orders.Queries.Keuken;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class KitchenOrdersController : ApiController
    {
        [HttpGet]

        public async Task<ActionResult<List<KeukenVm>>> Get()
        {
            return await Mediator.Send(new GetAlleKeukenBestellingenQuery());
        }
        

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, KeukenServedCommand command)
        {

            command.Id = id;
            if (id != command.Id)
            {
                return BadRequest();
            }
            await Mediator.Send(command);

            return NoContent();
        }


    }
}