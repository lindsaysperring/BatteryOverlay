﻿using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using BatteryOverlay.Extensions;
using BatteryOverlay.ViewModels;

namespace BatteryOverlay.Views;

public partial class MainWindow : Window
{
    private readonly MainViewModel _viewModel;

    public MainWindow()
    {
        InitializeComponent();
        _viewModel = (MainViewModel)DataContext!;
        this.MakeClickThrough();
        PositionWindow();
    }

    private void PositionWindow()
    {
        if (Screens.Primary != null)
        {
            var screen = Screens.Primary;
            Position = new PixelPoint(
                (int)(screen.Bounds.X + 10),
                (int)(screen.Bounds.Y + 10)
            );
        }
    }

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
        _viewModel.Dispose();
    }
}
