namespace DockingBayApi.Models;

public class Pilot
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Rank { get; set; } = string.Empty;
    public int FlightHours { get; set; }
    public bool IsOnDuty { get; set; }
}
