using Microsoft.AspNetCore.Mvc;
using MiniCqrs.Commands;
using MiniCqrs.Commands.CreateLead;
using MiniCqrs.Queries;

namespace MiniCqrs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeadsController : ControllerBase
{
    private readonly CreateLeadHandler _createLeadHandler;
    private readonly GetLeadByIdHandler _getLeadByIdHandler;

    public LeadsController(
        CreateLeadHandler createLeadHandler,
        GetLeadByIdHandler getLeadByIdHandler)
    {
        _createLeadHandler = createLeadHandler;
        _getLeadByIdHandler = getLeadByIdHandler;
    }

    [HttpPost]
    public IActionResult Create(CreateLeadCommand command)
    {
        _createLeadHandler.Handle(command);
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var lead = _getLeadByIdHandler.Handle(new GetLeadByIdQuery { Id = id });
        if (lead == null) return NotFound();
        return Ok(lead);
    }
}
