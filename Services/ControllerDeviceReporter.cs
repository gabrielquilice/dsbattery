using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSBattery.Enums;
using DSBattery.Interfaces;
using DSBattery.Models;

namespace DSBattery.Services;

public class ControllerDeviceReporter : IBatteryReporter
{
    private readonly IDeviceProvider _deviceProvider;

    public ControllerDeviceReporter(IDeviceProvider deviceProvider)
    {
        _deviceProvider = deviceProvider;
    }

    public async Task<List<ControllerDevice>> GetBatteryReport()
    {
        var dualshockDevices = await _deviceProvider.QueryConnected(DeviceKind.Dualshock4);
        var dualsenseDevices = await _deviceProvider.QueryConnected(DeviceKind.Dualsense);

        var sonyDevices = new List<ControllerDevice>(dualsenseDevices.Count + dualshockDevices.Count);
        sonyDevices.AddRange(dualshockDevices);
        sonyDevices.AddRange(dualsenseDevices);

        return sonyDevices;
    }
}