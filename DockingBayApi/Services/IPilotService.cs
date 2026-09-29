using DockingBayApi.Models;

namespace DockingBayApi.Services;

public interface IPilotService
{
    List<Pilot> GetAll();
    Pilot? GetById(int id);
    List<Pilot> GetOnDuty();
    int GetTotalHours();
    Pilot Create(Pilot pilot);
    bool LogHours(int id, int hours);
}
