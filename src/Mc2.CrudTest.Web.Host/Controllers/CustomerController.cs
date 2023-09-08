using Mc2.CrudTest.Application.Dtos.Customer;
using Mc2.CrudTest.Application.Features.Commands.Customer.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Web.Host.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CustomerController : ControllerBase
{

    private readonly ILogger<CustomerController> _logger;
    private readonly IMediator _mediator;


    public CustomerController(ILogger<CustomerController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> Create([FromBody][Required] CreateCustomerCommand command)
    => Ok(await _mediator.Send(command));

}
