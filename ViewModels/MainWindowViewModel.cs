using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using DSBattery.Interfaces;
using DSBattery.Models;
using DSBattery.Providers;
using DSBattery.Services;

namespace DSBattery.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<ControllerDevice> Items { get; } = [];
    
    private readonly CancellationTokenSource _cts = new();
    private static readonly IDeviceProvider DeviceProvider = new DeviceProvider();

    public MainWindowViewModel()
    {
        StartAutoRefresh();
    }

    private async void StartAutoRefresh()
    {
        try
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(3));

            while (await timer.WaitForNextTickAsync(_cts.Token))
            {
                await RefreshDevicesAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e}");
        }
    }

    private async Task RefreshDevicesAsync()
    {
        var reporter = new ControllerDeviceReporter(DeviceProvider);
        var result = await reporter.GetBatteryReport();

        Items.Clear();
        
        if (result.Count == 0)
        {
            return;
        }
        
        foreach (var device in result)
        {
            Items.Add(device);
        }
    }

    public void Dispose()
    {
        _cts.Cancel();
    }
}