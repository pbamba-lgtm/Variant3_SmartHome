namespace SmartHome.Patterns.Command;

public class CommandQueue
{
    private readonly Queue<ICommand> _pending = new();
    private readonly Stack<ICommand> _history = new();

    public void Enqueue(ICommand cmd)
    {
        _pending.Enqueue(cmd);
        Console.WriteLine($"  [Queue] + enqueued: {cmd.Description}");
    }

    public void ExecuteAll()
    {
        Console.WriteLine("  [Queue] flushing...");
        while (_pending.Count > 0)
        {
            var c = _pending.Dequeue();
            c.Execute();
            _history.Push(c);
        }
    }

    public void UndoLast()
    {
        if (_history.Count == 0) { Console.WriteLine("  [Queue] nothing to undo"); return; }
        var c = _history.Pop();
        Console.WriteLine($"  [Queue] undo last -> {c.Description}");
        c.Undo();
    }
}