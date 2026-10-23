namespace SmartHome.Models;

public enum DeviceState { Off, On }

public interface ISmartDevice
{
    string Id { get; }
    string Name { get; }
    DeviceState State { get; }
    void TurnOn();
    void TurnOff();
    string Describe();
}