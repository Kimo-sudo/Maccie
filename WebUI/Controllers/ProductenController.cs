using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Employees.Queries;
using Application.Products.Commands;
using Application.Products.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ProductenController : ApiController
    {
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await Mediator.Send(new GetAllProductsQuery());
        }
        [HttpPost]
        public async Task<ActionResult<int>> AddProduct(CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }

    }
}