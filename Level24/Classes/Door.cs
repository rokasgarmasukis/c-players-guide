namespace Classes;
public class Door
{
    private int _passcode;
    public State State { get; private set; }

    public Door(int passcode)
    {
        _passcode = passcode;
        State = State.Closed;
    }

    public void Open()
    {
        if (State == State.Closed) State = State.Open;
    }

    public void Close()
    {
        if (State == State.Open) State = State.Closed;
    }

    public void Lock()
    {
        if (State == State.Closed) State = State.Locked;
    }
    public void Unlock(int passcode)
    {
        if (State == State.Locked && passcode == _passcode) State = State.Closed;
    }

    public void ChangePasscode(int oldPasscode, int newPasscode)
    {
        if (_passcode == oldPasscode) _passcode = newPasscode;
    }
}

public enum State { Locked, Open, Closed };