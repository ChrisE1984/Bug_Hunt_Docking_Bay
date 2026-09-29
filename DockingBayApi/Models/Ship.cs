namespace DockingBayApi.Models;

public class Ship
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Captain { get; set; } = string.Empty;
    public int FuelPercent { get; set; } = 0;
    public bool IsDocked { get; set; }
}
