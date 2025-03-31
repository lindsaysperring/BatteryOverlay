using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using BatteryOverlay.ViewModels;
using BatteryOverlay.Views;

namespace BatteryOverlay;

public partial class App : Application
{
    private MainViewModel? _viewModel;
    private TrayIcon? _trayIcon;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        _viewModel = new MainViewModel();
        _trayIcon = Resources["MainTrayIcon"] as TrayIcon;

        if (_trayIcon != null)
        {
            var menu = new NativeMenu();
            var exitItem = new NativeMenuItem("Exit");
            exitItem.Click += (s, e) =>
            {
                if (Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                {
                    desktop.Shutdown();
                }
            };
            menu.Add(exitItem);
            _trayIcon.Menu = menu;
            _trayIcon.IsVisible = true;
        }
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0);

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = _viewModel
            };

            desktop.ShutdownRequested += (s, e) =>
            {
                if (_trayIcon != null)
                {
                    _trayIcon.IsVisible = false;
                    _trayIcon.Dispose();
                }
                _viewModel?.Dispose();
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
