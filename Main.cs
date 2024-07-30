using System.Diagnostics;
using System;

namespace paradigm_shift_csharp
{
class Main
{
   public static void Main()
    {
        BatterySystem battery = new BatterySystem(2.26f, 76.0f, 0.76f);
        Debug.Assert(battery.IsOk() == true);
        Console.WriteLine("Battery status: " + battery.GetStateStatusBatterySystem());

        battery.SetTemperature(2.25f);
        Console.WriteLine("Battery status: " + battery.GetStateStatusBatterySystem());

        battery.SetTemperature(2.26f);
        battery.SetChargeState(76.01f);
        Console.WriteLine("Battery status: " + battery.GetStateStatusBatterySystem());

        battery.SetTemperature(2.26f);
        battery.SetChargeState(76.00f);
        battery.SetChargeRate(0.81f);
        Debug.Assert(battery.IsOk() == false);
        Console.WriteLine("Battery status: " + battery.GetStateStatusBatterySystem());
    }
 }
}
