using SmartHome.Models;

namespace SmartHome.Patterns.Command;

public class TurnOnCommand : ICommand
{
    private readonly ISmartDevice _device;
    public string Description => $"TurnOn({_device.Name})";
    public TurnOnCommand(ISmartDevice device) => _device = device;

    public void Execute() { Console.WriteLine($"  -> Executing: {Description}"); _device.TurnOn(); }
    public void Undo() { Console.WriteLine($"  <- Undo: {Description}"); _device.TurnOff(); }
}

public class TurnOffCommand : ICommand
{
    private readonly ISmartDevice _device;
    public string Description => $"TurnOff({_device.Name})";
    public TurnOffCommand(ISmartDevice device) => _device = device;

    public void Execute() { Console.WriteLine($"  -> Executing: {Description}"); _device.TurnOff(); }
    public void Undo() { Console.WriteLine($"  <- Undo: {Description}"); _device.TurnOn(); }
}