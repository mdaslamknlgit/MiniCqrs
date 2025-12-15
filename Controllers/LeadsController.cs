using MiniCqrs.Commands;
using MiniCqrs.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MiniCqrs.Controllers;

[ApiController]
[Route("api/leads")]
public class LeadsController : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] CreateLeadCommand command)
    {
        var handler = new CreateLeadHandler();
        return Ok(handler.Handle(command));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var handler = new GetLeadByIdHandler();
        var lead = handler.Handle(new GetLeadByIdQuery { Id = id });
        return lead == null ? NotFound() : Ok(lead);
    }
}
