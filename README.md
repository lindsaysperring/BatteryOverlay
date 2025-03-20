# Battery Overlay

A lightweight Windows application that displays battery information as a transparent overlay on your screen.

## Features

- Shows battery percentage and remaining time
- Transparent, click-through overlay window
- Always-on-top display
- System tray icon with battery status tooltip
- Auto-updates every 30 seconds
- Hidden from taskbar
- Easy to close via system tray menu

## Requirements

- Windows operating system
- .NET 8.0 Runtime
- Windows Forms compatibility (for system tray icon)

## Development Setup

1. Install the .NET 8.0 SDK
2. Clone the repository
3. Build the solution:
   ```bash
   dotnet build
   ```

## Running the Application

Navigate to the project directory and run:
```bash
dotnet run --project BatteryOverlay.Desktop/BatteryOverlay.Desktop.csproj
```

Or run the compiled executable from:
```
BatteryOverlay.Desktop/bin/Debug/net8.0-windows/BatteryOverlay.Desktop.exe
```

## Project Structure

- `BatteryOverlay/` - Core library project
  - `Services/` - Battery and tray icon services
  - `ViewModels/` - MVVM view models
  - `Views/` - Avalonia UI views
  - `Extensions/` - Window extension methods
- `BatteryOverlay.Desktop/` - Windows desktop application

## Technologies Used

- [Avalonia UI](https://avaloniaui.net/) - Cross-platform .NET UI framework
- CommunityToolkit.Mvvm - Modern MVVM toolkit
- System.Management - Windows battery information
- Windows Forms - System tray functionality

## License

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program. If not, see <https://www.gnu.org/licenses/>.
