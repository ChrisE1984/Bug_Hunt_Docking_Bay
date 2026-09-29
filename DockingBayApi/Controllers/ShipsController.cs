using Microsoft.AspNetCore.Mvc;
using DockingBayApi.Models;
using DockingBayApi.Services;

namespace DockingBayApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipsController : ControllerBase
{
    private readonly IShipService _ships;

    public ShipsController(IShipService ships)
    {
        _ships = ships;
    }

    [HttpGet("GetAll")]
    public ActionResult<List<Ship>> GetAll()
    {
        List<Ship> ships = _ships.GetAll();
        return Ok(ships);
    }

    [HttpGet("docked")]
    public ActionResult<List<Ship>> GetDocked()
    {
        List<Ship> docked = _ships.GetDocked();
        return Ok(docked);
    }

    [HttpGet("{id}")]
    public ActionResult<Ship> GetById(int id)
    {
        Ship? ship = _ships.GetById(id);

        if (ship == null)
        {
            return NotFound($"No ship with id {id}.");
        }

        return Ok(ship);
    }

    [HttpPost]
    public ActionResult<Ship> Create(Ship ship)
    {
        Ship created = _ships.Create(ship);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}/refuel")]
    public IActionResult Refuel(int id)
    {
        bool refueled = _ships.Refuel(id);

        if (!refueled)
        {
            return NotFound($"No ship with id {id}.");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool deleted = _ships.Delete(id);

        if (!deleted)
        {
            return NotFound($"No ship with id {id}.");
        }

        return NoContent();
    }
}
