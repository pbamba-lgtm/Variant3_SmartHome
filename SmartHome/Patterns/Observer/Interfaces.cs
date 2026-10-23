namespace SmartHome.Patterns.Observer;

public interface IObserver
{
    void OnSensorChanged(string sensorId, double value);
}

public interface ISubject
{
    void Subscribe(IObserver o);
    void Unsubscribe(IObserver o);
    void Notify(double value);
}

public record SensorReading(string SensorId, double Value, DateTime Timestamp);