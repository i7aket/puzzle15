namespace Puzzle15;

public class ChangeTimeSpent
{
    private readonly Timer _timer;

    public ChangeTimeSpent(TimerCallback callback, object state=null, int dueTime=1000, int period=1000)
    {
        _timer = new Timer(callback, state, dueTime, period);
    }

    public void Start()
    {
        _timer.Change(1000, 1000);
    }

    public void Stop()
    {
        _timer.Change(Timeout.Infinite,  Timeout.Infinite);
    }
    
}