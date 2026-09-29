using DockingBayApi.Models;

namespace DockingBayApi.Services;

public class PilotService : IPilotService
{
    private static readonly List<Pilot> _pilots = new()
    {
        new Pilot { Id = 1, Name = "Maya Chen",  Rank = "Commander",  FlightHours = 1200, IsOnDuty = true  },
        new Pilot { Id = 2, Name = "Leo Brandt", Rank = "Lieutenant", FlightHours = 340,  IsOnDuty = false },
        new Pilot { Id = 3, Name = "Ana Ruiz",   Rank = "Ensign",     FlightHours = 85,   IsOnDuty = true  },
    };

    private static int _nextId = 4;

    public List<Pilot> GetAll()
    {
        return _pilots.OrderBy(p => p.Id).ToList();
    }

    public Pilot? GetById(int id)
    {
        return _pilots.FirstOrDefault(p => p.Id == id);
    }

    public List<Pilot> GetOnDuty()
    {
        return _pilots.Where(p => p.IsOnDuty).ToList();
    }

    public int GetTotalHours()
    {
        return _pilots.Sum(p => p.FlightHours);
    }

    public Pilot Create(Pilot pilot)
    {
        pilot.Id = _nextId;

        pilot.FlightHours = 0;

        _pilots.Add(pilot);
        return pilot;
    }

    public bool LogHours(int id, int hours)
    {
        Pilot? pilot = _pilots.FirstOrDefault(p => p.Id == id);

        if (pilot == null)
        {
            return false;
        }

        pilot.FlightHours += hours;
        return true;
    }
}
