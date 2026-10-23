using SmartHome.Models;
using SmartHome.Patterns.Command;

namespace SmartHome;

public class SmartHomeHub
{
    private readonly Dictionary<string, ISmartDevice> _devices = new();
    public CommandQueue Commands { get; } = new();

    public void Register(ISmartDevice device)
    {
        _devices[device.Id] = device;
        Console.WriteLine($"  [Hub] registered: {device.Describe()}");
    }

    public ISmartDevice Get(string id) => _devices[id];
    public IEnumerable<ISmartDevice> All() => _devices.Values;
}