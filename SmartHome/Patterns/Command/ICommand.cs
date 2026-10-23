namespace SmartHome.Patterns.Command;

public interface ICommand
{
    string Description { get; }
    void Execute();
    void Undo();
}