using System;
using System.Timers;
using CommunityToolkit.Mvvm.ComponentModel;
using BatteryOverlay.Services;

namespace BatteryOverlay.ViewModels;

public partial class MainViewModel : ViewModelBase, IDisposable
{
    private readonly BatteryService _batteryService;
    private readonly TrayIconService _trayIconService;
    private readonly Timer _updateTimer;
    private bool _disposed;

    [ObservableProperty]
    private int _batteryPercentage;

    [ObservableProperty]
    private string _timeRemaining = "Unknown";

    public MainViewModel()
    {
        _batteryService = new BatteryService();
        _trayIconService = new TrayIconService(this);
        
        _updateTimer = new Timer(30000); // Update every 30 seconds
        _updateTimer.Elapsed += UpdateBatteryInfo;
        _updateTimer.Start();

        UpdateBatteryInfo(null, null); // Initial update
    }

    private void UpdateBatteryInfo(object? sender, ElapsedEventArgs? e)
    {
        var batteryInfo = _batteryService.GetBatteryInfo();
        BatteryPercentage = batteryInfo.Percentage;
        TimeRemaining = batteryInfo.TimeRemaining?.ToString(@"hh\:mm") ?? "Unknown";

        _trayIconService.UpdateTooltip($"Battery: {BatteryPercentage}% - {TimeRemaining} remaining");
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _updateTimer.Dispose();
            _trayIconService.Dispose();
            _disposed = true;
        }
    }
}
