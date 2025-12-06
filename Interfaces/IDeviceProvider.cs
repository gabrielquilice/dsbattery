using System.Collections.Generic;
using System.Threading.Tasks;
using DSBattery.Enums;
using DSBattery.Models;

namespace DSBattery.Interfaces;

public interface IDeviceProvider
{
    Task<IReadOnlyCollection<ControllerDevice>> QueryConnected(DeviceKind kind);
    IReadOnlyCollection<ControllerDevice> QueryCached();
}