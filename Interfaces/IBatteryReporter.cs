using System.Collections.Generic;
using System.Threading.Tasks;
using DSBattery.Models;

namespace DSBattery.Interfaces
{
    public interface IBatteryReporter
    {
        Task<List<ControllerDevice>> GetBatteryReport();
    }
}