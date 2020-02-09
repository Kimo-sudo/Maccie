using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Orders.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class KitchenOrdersController : ApiController
    {
        [HttpGet]

        public async Task<ActionResult<List<KitchenOrderVm>>> Get()
        {
            return await Mediator.Send(new GetKitchenQuery());
        }
    }
}