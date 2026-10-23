using SmartHome.Models;

namespace SmartHome.Devices;

public class OwnSocket : ISmartDevice
{
    public string Id { get; }
    public string Name { get; }
    public DeviceState State { get; private set; } = DeviceState.Off;

    public OwnSocket(string id, string name) { Id = id; Name = name; }

    public void TurnOn() { State = DeviceState.On; Console.WriteLine($"  [Socket '{Name}'] => powered"); }
    public void TurnOff() { State = DeviceState.Off; Console.WriteLine($"  [Socket '{Name}'] => unpowered"); }
    public string Describe() => $"{Name} (socket) = {State}";
}