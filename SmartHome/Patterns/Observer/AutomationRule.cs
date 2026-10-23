namespace SmartHome.Patterns.Observer;

public class AutomationRule : IObserver
{
    private readonly string _name;
    private readonly Func<double, bool> _condition;
    private readonly Action _action;
    private readonly Action? _rollback;

    public AutomationRule(string name, Func<double, bool> condition, Action action, Action? rollback = null)
    {
        _name = name; _condition = condition; _action = action; _rollback = rollback;
    }

    public void OnSensorChanged(string sensorId, double value)
    {
        bool ok = _condition(value);
        Console.WriteLine($"  [Rule '{_name}'] evaluated on sensor {sensorId}: {ok}");
        if (ok) _action();
        else _rollback?.Invoke();
    }
}