using SmartHome.Models;
using SmartHome.Devices;

namespace SmartHome.Patterns.Adapter;

public class AcmeThermostatAdapter : ISmartDevice
{
    private readonly AcmeThermostat _acme;

    public string Id { get; }
    public string Name { get; }
    public DeviceState State => _acme.IsHeating ? DeviceState.On : DeviceState.Off;

    public AcmeThermostatAdapter(string id, string name, AcmeThermostat acme)
    {
        Id = id; Name = name; _acme = acme;
    }

    public void TurnOn() => _acme.StartHeating();
    public void TurnOff() => _acme.StopHeating();
    public string Describe() => $"{Name} (ACME adapter #{_acme.Serial}) = {State}, target={_acme.GetTargetTemperature()}C";
}