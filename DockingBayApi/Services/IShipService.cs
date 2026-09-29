using DockingBayApi.Models;

namespace DockingBayApi.Services;

public interface IShipService
{
    List<Ship> GetAll();
    Ship? GetById(int id);
    List<Ship> GetDocked();
    Ship Create(Ship ship);
    bool Refuel(int id);
    bool Delete(int id);
}
