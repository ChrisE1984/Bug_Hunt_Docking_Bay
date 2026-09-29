using Microsoft.AspNetCore.Mvc;
using DockingBayApi.Models;
using DockingBayApi.Services;

namespace DockingBayApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PilotsController : ControllerBase
{
    private readonly IPilotService _pilots;

    public PilotsController(IPilotService pilots)
    {
        _pilots = pilots;
    }

    [HttpGet("getall")]
    public ActionResult<List<Pilot>> GetAll()
    {
        List<Pilot> pilots = _pilots.GetAll();
        return Ok(pilots);
    }

    [HttpGet("on-duty")]
    public ActionResult<List<Pilot>> GetOnDuty()
    {
        List<Pilot> onDuty = _pilots.GetOnDuty();
        return Ok(onDuty);
    }

    [HttpGet("total-hours")]
    public ActionResult<int> GetTotalHours()
    {
        int total = _pilots.GetTotalHours();
        return Ok(total);
    }

    [HttpGet("{id}")]
    public ActionResult<Pilot> GetById(int id)
    {
        Pilot? pilot = _pilots.GetById(id);

        if (pilot == null)
        {
            return NotFound($"No pilot with id {id}.");
        }

        return Ok(pilot);
    }

    [HttpPost]
    public ActionResult<Pilot> Create(Pilot pilot)
    {
        Pilot created = _pilots.Create(pilot);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}/log-hours/{hours}")]
    public IActionResult LogHours(int id, int hours)
    {
        if (hours < 0)
        {
            return BadRequest("Hours must be greater than 0.");
        }

        bool logged = _pilots.LogHours(id, hours);

        if (!logged)
        {
            return NotFound($"No pilot with id {id}.");
        }

        return NoContent();
    }
}
