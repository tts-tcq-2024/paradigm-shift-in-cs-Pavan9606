using System;

namespace paradigm_shift_csharp
{
    public class BatterySystem
 {
     private readonly ParameterMonitoring _monitorTemperature;
     private readonly ParameterMonitoring _monitorChargeState;
     private readonly ParameterMonitoring _monitorChargeRate;

     public BatterySystem(float temperature, float chargeState, float chargeRate)
     {
         _monitorTemperature = new ParameterMonitoring("TEMPERATURE", temperature, 0.0f, 45.0f, 45.0f * 0.05f);
         _monitorChargeState = new ParameterMonitoring("SOC", chargeState, 20.0f, 80.0f, 80.0f * 0.05f);
         _monitorChargeRate = new ParameterMonitoring("CHARGE_RATE", chargeRate, 0.0f, 0.8f, 0.8f * 0.05f);
     }
     public bool IsOk()
     {
         return _monitorTemperature.IsOk() && _monitorChargeState.IsOk() && _monitorChargeRate.IsOk();
     }
     public string GetStateStatusBatterySystem()
     {
         string status = _monitorTemperature.GetStateStatus();
         status += " ";
         status += _monitorChargeState.GetStateStatus();
         status += " ";
         status += _monitorChargeRate.GetStateStatus();
         return status;
     }

     public void SetTemperature(float input)
     {
         _monitorTemperature.SetValue(input);
     }

     public void SetChargeState(float input)
     {
         _monitorChargeState.SetValue(input);
     }

     public void SetChargeRate(float input)
     {
         _monitorChargeRate.SetValue(input);
     }
 }
}
