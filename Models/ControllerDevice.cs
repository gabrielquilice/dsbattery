using DSBattery.Enums;

namespace DSBattery.Models;

public class ControllerDevice(string path)
{
    public string Path { get; set; } = path;
    public int BatteryPercentage { get; set; }
    public DeviceStatus Status { get; set; }
    public string? Mac { get; set; }
    public DeviceKind Kind { get; set; }
}