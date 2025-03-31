using System;
using Avalonia;
using Avalonia.Controls;
using BatteryOverlay.ViewModels;

namespace BatteryOverlay.Services;

public class TrayIconService : IDisposable
{
    private readonly MainViewModel _viewModel;
    private bool _disposed;

    public TrayIconService(MainViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public void UpdateTooltip(string text)
    {
        if (!_disposed && Application.Current != null)
        {
            var trayIcon = Application.Current.Resources["MainTrayIcon"] as TrayIcon;
            if (trayIcon != null)
            {
                trayIcon.ToolTipText = text;
            }
        }
    }

    public void Dispose()
    {
        _disposed = true;
    }
}
