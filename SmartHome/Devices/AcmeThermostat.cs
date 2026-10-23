namespace SmartHome.Devices;

public class AcmeThermostat
{
    public string Serial { get; }
    private bool _heating;
    private readonly int _targetTemp;

    public AcmeThermostat(string serial, int targetTemp = 22)
    {
        Serial = serial;
        _targetTemp = targetTemp;
    }

    public void StartHeating() { _heating = true; Console.WriteLine($"  [ACME #{Serial}] heating started (target {_targetTemp}C)"); }
    public void StopHeating() { _heating = false; Console.WriteLine($"  [ACME #{Serial}] heating stopped"); }
    public bool IsHeating => _heating;
    public int GetTargetTemperature() => _targetTemp;
}