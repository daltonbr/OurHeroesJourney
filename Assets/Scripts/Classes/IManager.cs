public enum ManagerState
{
    Offline,
    Initializing,
    Completed
}

public interface IManager
{
    ManagerState CurrentState { get; }

    void BootSequence();
}
