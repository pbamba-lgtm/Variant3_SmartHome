using SmartHome.Models;

namespace SmartHome.Devices;

public class OwnLight : ISmartDevice
{
    public string Id { get; }
    public string Name { get; }
    public DeviceState State { get; private set; } = DeviceState.Off;

    public OwnLight(string id, string name) { Id = id; Name = name; }

    public void TurnOn() { State = DeviceState.On; Console.WriteLine($"  [Lamp '{Name}'] => ON"); }
    public void TurnOff() { State = DeviceState.Off; Console.WriteLine($"  [Lamp '{Name}'] => OFF"); }
    public string Describe() => $"{Name} (light) = {State}";
}