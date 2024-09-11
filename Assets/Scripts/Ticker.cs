using System;
using System.Threading.Tasks;

public class Ticker {
    private int _duration;
    private bool _isPause;
    private Action _onTick;
    public Ticker(float duration, Action onTick)
    {
        _onTick = onTick;
        _isPause = false;
        SetDuration(duration);
        TickLoop();
    }
    public void SetDuration(float duration)
    {
        _duration = (int)(duration * 1000);
    }
    public void SetPause(bool isPause)
    {
        _isPause = isPause;
    }
    private async void TickLoop()
    {
        while (true)
        {
            await Task.Delay(_duration);

            if (!_isPause) {
                _onTick.Invoke();
            }
        }
    }
}
