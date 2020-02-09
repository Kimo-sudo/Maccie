using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Application.Employees.Commands;
using Application.Employees.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await Mediator.Send(new GetAllEmployeesQuery());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await Mediator.Send(new GetEmployeeDetailQuery {Id = id});
            return Ok(employee);

        }

        [HttpPost]
        public async Task<int> CreateEmployee(CreateEmployeeCommand command)
        {
            return await Mediator.Send(command);
        }


    }
}

