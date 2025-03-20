using System;
using System.Windows.Forms;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using BatteryOverlay.ViewModels;

namespace BatteryOverlay.Services;

public class TrayIconService : IDisposable
{
    private readonly NotifyIcon _notifyIcon;
    private readonly MainViewModel _viewModel;
    private bool _disposed;

    public TrayIconService(MainViewModel viewModel)
    {
        _viewModel = viewModel;
        _notifyIcon = new NotifyIcon
        {
            Icon = System.Drawing.SystemIcons.Application,
            Visible = true,
            Text = "Battery Overlay"
        };

        InitializeContextMenu();
    }

    private void InitializeContextMenu()
    {
        var contextMenu = new ContextMenuStrip();
        var exitItem = new ToolStripMenuItem("Exit");
        exitItem.Click += (s, e) => 
        {
            if (Avalonia.Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.Shutdown();
            }
        };

        contextMenu.Items.Add(exitItem);
        _notifyIcon.ContextMenuStrip = contextMenu;
    }

    public void UpdateTooltip(string text)
    {
        if (!_disposed)
        {
            _notifyIcon.Text = text;
        }
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _notifyIcon.Visible = false;
            _notifyIcon.Dispose();
            _disposed = true;
        }
    }
}
