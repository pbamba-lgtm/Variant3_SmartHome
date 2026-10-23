using SmartHome;
using SmartHome.Devices;
using SmartHome.Models;
using SmartHome.Patterns.Adapter;
using SmartHome.Patterns.Command;
using SmartHome.Patterns.Observer;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("===== VARIANTE 3 -- MAISON INTELLIGENTE =====\n");

var hub = new SmartHomeHub();

Console.WriteLine("--- [Adapter] Connexion d'un thermostat ACME incompatible ---");
var acme = new AcmeThermostat("ACME-9001", 24);
ISmartDevice acmeAdapter = new AcmeThermostatAdapter("dev-acme", "Thermostat Salon", acme);

var lamp = new OwnLight("dev-lamp", "Lampe Cuisine");
var socket = new OwnSocket("dev-socket", "Prise TV");

hub.Register(lamp);
hub.Register(socket);
hub.Register(acmeAdapter);

Console.WriteLine("\n--- [Command] Enqueue des actions puis execution differee ---");
hub.Commands.Enqueue(new TurnOnCommand(lamp));
hub.Commands.Enqueue(new TurnOnCommand(socket));
hub.Commands.Enqueue(new TurnOnCommand(acmeAdapter));
Console.WriteLine("  (rien ne s'est encore passe -- execution differee)");
hub.Commands.ExecuteAll();

Console.WriteLine("\n  >> undo de la derniere commande (thermostat)");
hub.Commands.UndoLast();

Console.WriteLine("\n--- [Observer] Capteur de temperature + regles automatiques ---");
var sensor = new TemperatureSensor("sensor-temp-salon");

var ruleTooHot = new AutomationRule(
    "Temp > 26 => clim ON",
    v => v > 26,
    () => { Console.WriteLine("    -> Activation du thermostat"); acmeAdapter.TurnOn(); },
    () => { Console.WriteLine("    -> Temp OK : arret du thermostat"); acmeAdapter.TurnOff(); });

var ruleTooCold = new AutomationRule(
    "Temp < 18 => chauffage ON",
    v => v < 18,
    () => { Console.WriteLine("    -> Activation du chauffage"); acmeAdapter.TurnOn(); },
    () => { });

sensor.Subscribe(ruleTooHot);
sensor.Subscribe(ruleTooCold);

sensor.SetTemperature(22);
sensor.SetTemperature(28);
sensor.SetTemperature(30);
sensor.SetTemperature(15);
sensor.SetTemperature(24);

Console.WriteLine("\n--- Etat final du hub ---");
foreach (var d in hub.All())
    Console.WriteLine("  " + d.Describe());

Console.WriteLine("\n===== FIN DE LA DEMO =====");