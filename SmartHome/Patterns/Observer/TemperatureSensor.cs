namespace SmartHome.Patterns.Observer;

public class TemperatureSensor : ISubject
{
    public string Id { get; }
    private readonly List<IObserver> _observers = new();

    public TemperatureSensor(string id) => Id = id;

    public void Subscribe(IObserver o) => _observers.Add(o);
    public void Unsubscribe(IObserver o) => _observers.Remove(o);

    public void SetTemperature(double value)
    {
        Console.WriteLine($"  [Sensor '{Id}'] reported {value}C");
        Notify(value);
    }

    public void Notify(double value)
    {
        foreach (var o in _observers)
            o.OnSensorChanged(Id, value);
    }
}