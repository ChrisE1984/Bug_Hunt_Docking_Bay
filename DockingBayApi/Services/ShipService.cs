using DockingBayApi.Models;

namespace DockingBayApi.Services;

public class ShipService : IShipService
{
    private static readonly List<Ship> _ships = new()
    {
        new Ship { Id = 1, Name = "Nova Runner", Captain = "Reyes",     FuelPercent = 80, IsDocked = true  },
        new Ship { Id = 2, Name = "Iron Comet",  Captain = "Okafor",    FuelPercent = 45, IsDocked = false },
        new Ship { Id = 3, Name = "Silver Wren", Captain = "Lindqvist", FuelPercent = 60, IsDocked = true  },
    };

    public List<Ship> GetAll()
    {
        return _ships.OrderBy(s => s.Id).ToList();
    }

    public Ship? GetById(int id)
    {
        return _ships.FirstOrDefault(s => s.Id == id);
    }
      
    public List<Ship> GetDocked()
    {
        return _ships.Where(s => s.IsDocked == true).ToList();
    }

    public Ship Create(Ship ship)
    {
        int newId = 1;
        while (_ships.Any(s => s.Id == newId))
        {
            newId += 1;
        }

        ship.Id = newId;
        ship.IsDocked = true;
        ship.FuelPercent = 100;

        _ships.Add(ship);
        return ship;
    }

    public bool Refuel(int id)
    {
        Ship? ship = _ships.FirstOrDefault(s => s.Id == id);

        if (ship == null)
        {
            return false;
        }

        ship.FuelPercent = 100;
        return true;
    }

    public bool Delete(int id)
    {
        bool removed = false;

        foreach (Ship ship in _ships.ToList())
        {
            if (ship.Id == id)
            {
                _ships.Remove(ship);
                removed = true;
            }
        }

        return removed;
    }
}
