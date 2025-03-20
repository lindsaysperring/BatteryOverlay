using System;
using System.Management;
using System.Threading.Tasks;

namespace BatteryOverlay.Services;

public class BatteryService
{
    public record BatteryInfo(int Percentage, TimeSpan? TimeRemaining);

    public BatteryInfo GetBatteryInfo()
    {
        try
        {
            using var searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Battery");
            using var collection = searcher.Get();

            foreach (var battery in collection)
            {
                var percentRemaining = Convert.ToInt32(battery["EstimatedChargeRemaining"]);
                var estimatedRunTime = Convert.ToInt32(battery["EstimatedRunTime"]);
                
                TimeSpan? timeRemaining = estimatedRunTime > 0 
                    ? TimeSpan.FromMinutes(estimatedRunTime)
                    : null;

                return new BatteryInfo(percentRemaining, timeRemaining);
            }
        }
        catch (Exception)
        {
            // Log or handle error as needed
        }

        return new BatteryInfo(0, null);
    }
}
